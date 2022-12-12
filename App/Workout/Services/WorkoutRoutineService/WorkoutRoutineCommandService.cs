using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRoutineRepository;
using SaveApp.App.Workout.Services.ExerciseSetService;
using SaveApp.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Services.WorkoutRoutineService
{
    public class WorkoutRoutineCommandService : IWorkoutRoutineCommandService
    {
        private readonly IWorkoutRoutineCommandRepository _commandRepository;
        private readonly IWorkoutCommandService _workoutCommandService;
        private readonly IExerciseSetCommandService _exerciseSetCommandService;
        private readonly IWorkoutQueryService _workoutQueryService;
        private readonly IWorkoutRoutineQueryService _queryService;

        public WorkoutRoutineCommandService(
            IWorkoutRoutineCommandRepository commandRepository,
            IWorkoutCommandService workoutCommandService,
            IExerciseSetCommandService exerciseSetCommandService,
            IWorkoutQueryService workoutQueryService,
            IWorkoutRoutineQueryService queryService
        )
        {
            _commandRepository = commandRepository;
            _workoutQueryService = workoutQueryService;
            _exerciseSetCommandService = exerciseSetCommandService;
            _queryService = queryService;
            _workoutCommandService = workoutCommandService;
        }

        public int Create()
        {
            return _commandRepository.Create();
        }

        public int CreateWithInput(int workoutId)
        {
            WorkoutDetails workout = _workoutQueryService.GetByWorkoutId(workoutId);

            List<WorkoutRoutineExercise> routineExercises = workout.Exercises!
                .Select(
                    o =>
                        new WorkoutRoutineExercise
                        {
                            Exercise = o.Exercise,
                            Notes = string.Empty,
                            NumberOfSets = o.ExerciseSets != null ? o.ExerciseSets.Count : 0
                        }
                )
                .ToList();

            WorkoutRoutine routine =
                new()
                {
                    Name = workout.Name,
                    Notes = workout.Notes,
                    WorkoutRoutineExercises = routineExercises
                };

            return _commandRepository.CreateWithInput(routine);
        }

        public int CreateWorkoutFromRoutine(int routineId)
        {
            WorkoutRoutine routine = _queryService.GetById(routineId);

            WorkoutDetails workout =
                new()
                {
                    Name = routine.Name,
                    Notes = routine.Notes,
                    Date = DateTime.UtcNow,
                    StartTime = DateTime.UtcNow
                };

            int createdWorkoutId = _workoutCommandService.CreateFromRoutine(workout);

            if (
                routine.WorkoutRoutineExercises != null
                && routine.WorkoutRoutineExercises.Count != 0
            )
            {
                foreach (var item in routine.WorkoutRoutineExercises)
                {
                    WorkoutExercise exercise = _workoutCommandService.AddExerciseToWorkout(
                        new AddExerciseToWorkoutInput()
                        {
                            Exercise = item.Exercise,
                            RowNumber = item.RowNumber,
                            WorkoutId = createdWorkoutId
                        }
                    );

                    for (var i = 1; item.NumberOfSets > i; i++)
                    {
                        _exerciseSetCommandService.CreateSetForRoutine(
                            item.Exercise.Id,
                            (int)exercise.Id
                        );
                    }
                }
            }

            return createdWorkoutId;
        }

        public WorkoutRoutine CopyRoutine(int routineId) {
            return _commandRepository.CopyRoutine(routineId);
        }

        public void Delete(int workoutRoutineId)
        {
            _commandRepository.Delete(workoutRoutineId);
        }

        public void Update(WorkoutRoutine input)
        {
            _commandRepository.Update(input);
        }
    }
}
