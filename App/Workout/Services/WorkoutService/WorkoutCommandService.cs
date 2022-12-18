using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Repositories.WorkoutRepository;
using SaveApp.App.Workout.Services.ExerciseSetService;
using SaveApp.App.Workout.Services.WorkoutRoutineService;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutCommandService : IWorkoutCommandService
    {
        private readonly IWorkoutCommandRepository _commandRepository;
        private readonly IWorkoutQueryRepository _queryRepository;
        private readonly IExerciseSetCommandService _exerciseSetCommandService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public WorkoutCommandService(
            IWorkoutCommandRepository commandRepository,
            IWorkoutQueryRepository queryRepository,
            IExerciseSetCommandService exerciseSetCommandService,
            ILogger<string> logger,
            IMapper mapper
        )
        {
            _commandRepository = commandRepository;
            _exerciseSetCommandService = exerciseSetCommandService;
            _logger = logger;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public int Create()
        {
            return _commandRepository.Create(
                new WorkoutDetailsCreateInput()
                {
                    Date = DateTime.UtcNow,
                    StartTime = DateTime.UtcNow
                }
            );
        }

        public int CreateFromRoutine(WorkoutDetails routine)
        {
            return _commandRepository.CreateFromRoutine(routine);
        }

        public WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise)
        {
            WorkoutExercise addedExercise = _commandRepository.AddExerciseToWorkout(exercise);

            ExerciseSetCreateInput set = new ExerciseSetCreateInput();
            set.Weight = 0.0;
            set.Reps = 0;
            set.ExerciseId = exercise.Exercise.Id;
            set.WorkoutExerciseId = (int)addedExercise.Id;

            ExerciseSet createdSet = _exerciseSetCommandService.Create(set);

            addedExercise.ExerciseSets!.Add(createdSet);

            return addedExercise;
        }

        public void Update(WorkoutDetailsUpdateInput workoutDetails)
        {
            _commandRepository.Update(workoutDetails);
        }

        public void UpdateExercises(List<WorkoutExercise> exercises)
        {
            _commandRepository.UpdateExercises(exercises);
        }

        public void DeleteWorkoutExercise(int workoutExerciseId)
        {
            _commandRepository.DeleteWorkoutExercise(workoutExerciseId);
        }

        public void DeleteWorkout(int workoutId)
        {
            _commandRepository.DeleteWorkout(workoutId);
        }

        public int RepeatWorkout(int workoutId)
        {
            WorkoutDetails details = _queryRepository.GetWorkout(workoutId);
            List<WorkoutExercise> workoutExercises = details.Exercises;
            details.Id = null;
            details.Exercises = new List<WorkoutExercise>();
            details.EndTime = null;
            details.Date = DateTime.UtcNow;
            details.StartTime = DateTime.UtcNow;

            int returnedWorkoutId = _commandRepository.Create(
                _mapper.Map<WorkoutDetailsCreateInput>(details)
            );

            foreach (var workoutExercise in workoutExercises)
            {
                WorkoutExercise createdWorkoutExercise = _commandRepository.AddExerciseToWorkout(
                    new AddExerciseToWorkoutInput
                    {
                        Exercise = workoutExercise.Exercise,
                        RowNumber = workoutExercise.RowNumber,
                        WorkoutId = returnedWorkoutId
                    }
                );

                foreach (var set in workoutExercise.ExerciseSets)
                {
                    _logger.LogInformation(returnedWorkoutId.ToString());
                    _exerciseSetCommandService.Create(
                        new ExerciseSetCreateInput
                        {
                            Weight = set.Weight,
                            Reps = set.Reps,
                            Notes = set.Notes,
                            ExerciseId = workoutExercise.Exercise.Id,
                            WorkoutExerciseId = (int)createdWorkoutExercise.Id,
                            IndexOfSet = 0,
                        }
                    );
                }
            }

            return returnedWorkoutId;
        }
    }
}
