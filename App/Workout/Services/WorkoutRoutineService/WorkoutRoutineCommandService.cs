using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRoutineRepository;
using SaveApp.App.Workout.Services.ExerciseSetService;
using SaveApp.App.Workout.Services.WorkoutRoutineExerciseService;
using SaveApp.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Services.WorkoutRoutineService
{
    public class WorkoutRoutineCommandService : IWorkoutRoutineCommandService
    {
        private readonly IWorkoutRoutineCommandRepository _commandRepository;
        private readonly IWorkoutRoutineExerciseCommandService _workoutRoutineExerciseCommandService;
        private readonly IWorkoutCommandService _workoutCommandService;
        private readonly IExerciseSetCommandService _exerciseSetCommandService;
        private readonly IWorkoutQueryService _workoutQueryService;
        private readonly IWorkoutRoutineQueryService _queryService;

        public WorkoutRoutineCommandService(
            IWorkoutRoutineCommandRepository commandRepository,
            IWorkoutRoutineExerciseCommandService workoutRoutineExerciseCommandService,
            IWorkoutCommandService workoutCommandService,
            IExerciseSetCommandService exerciseSetCommandService,
            IWorkoutQueryService workoutQueryService,
            IWorkoutRoutineQueryService queryService
        )
        {
            _commandRepository = commandRepository;
            _workoutRoutineExerciseCommandService = workoutRoutineExerciseCommandService;
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

            WorkoutRoutine routine = new() { Name = workout.Name, Notes = workout.Notes };

            int newRoutineId = _commandRepository.CreateWithInput(routine);

            List<AddExerciseToRoutineInput> routineExercises = workout.Exercises!
                .Select(
                    o =>
                        new AddExerciseToRoutineInput
                        {
                            RoutineId = newRoutineId,
                            ExerciseId = o.Exercise!.Id,
                            NumberOfSets = o.ExerciseSets != null ? o.ExerciseSets.Count : 1
                        }
                )
                .ToList();

            for (var i = 0; i < routineExercises.Count; i++)
            {
                routineExercises[i].RowNumber = i + 1;
                _workoutRoutineExerciseCommandService.CreateForWorkoutRoutine(routineExercises[i]);
            }

            return newRoutineId;
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

        public WorkoutRoutine CopyRoutine(int routineId)
        {
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
