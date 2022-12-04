using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Repositories.WorkoutRepository;
using SaveApp.App.Workout.Services.ExerciseSetService;

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

        public int Create(int userId)
        {
            return _commandRepository.Create(
                userId,
                new WorkoutDetailsCreateInput()
                {
                    Date = DateTime.UtcNow,
                    StartTime = DateTime.UtcNow
                }
            );
        }

        public WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise)
        {
            WorkoutExercise addedExercise = _commandRepository.AddExerciseToWorkout(
                userId,
                exercise
            );

            ExerciseSetCreateInput set = new ExerciseSetCreateInput();
            set.Weight = 0;
            set.Reps = 0;
            set.ExerciseId = exercise.Exercise.Id;
            set.WorkoutExerciseId = (int)addedExercise.Id;
            set.UserId = userId;

            ExerciseSet createdSet = _exerciseSetCommandService.Create(set);

            addedExercise.ExerciseSets!.Add(createdSet);

            return addedExercise;
        }

        public void Update(int userId, WorkoutDetailsUpdateInput workoutDetails)
        {
            _commandRepository.Update(userId, workoutDetails);
        }

        public void DeleteWorkoutExercise(int userId, int workoutExerciseId)
        {
            _commandRepository.DeleteWorkoutExercise(userId, workoutExerciseId);
        }

        public void DeleteWorkout(int userId, int workoutId)
        {
            _commandRepository.DeleteWorkout(userId, workoutId);
        }

        public int RepeatWorkout(int userId, int workoutId) {
            WorkoutDetails details = _queryRepository.GetWorkout(userId, workoutId);
            List<WorkoutExercise> workoutExercises = details.Exercises;
            details.Id = null;
            details.Exercises = new List<WorkoutExercise>();
            details.EndTime = null;
            details.Date = DateTime.UtcNow;
            details.StartTime = DateTime.UtcNow;

            int returnedWorkoutId = _commandRepository.Create(userId, _mapper.Map<WorkoutDetailsCreateInput>(details));

            foreach (var workoutExercise in workoutExercises)
            {
                WorkoutExercise createdWorkoutExercise = _commandRepository.AddExerciseToWorkout(
                userId, 
                new AddExerciseToWorkoutInput{
                    Exercise = workoutExercise.Exercise,
                    RowNumber = workoutExercise.RowNumber,
                    WorkoutId = returnedWorkoutId});

                    foreach (var set in workoutExercise.ExerciseSets)
                    {
                        _logger.LogInformation("Second loop entered");
                        _logger.LogInformation("Second loop entered");
                        _logger.LogInformation("Second loop entered");
                        _logger.LogInformation("Second loop entered");
                        _logger.LogInformation("Second loop entered");
                        _logger.LogInformation(returnedWorkoutId.ToString());
                        _exerciseSetCommandService.Create(new ExerciseSetCreateInput{
                            Weight = set.Weight,
                            Reps = set.Reps,
                            Notes = set.Notes,
                            ExerciseId = workoutExercise.Exercise.Id,
                            WorkoutExerciseId = (int)createdWorkoutExercise.Id,
                            UserId = userId,
                            IndexOfSet = 0,
                        });
                    }
            } 

            return returnedWorkoutId;
        }
    }
}
