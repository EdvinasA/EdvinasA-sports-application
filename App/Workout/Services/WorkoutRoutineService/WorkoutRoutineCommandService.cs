using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRoutineRepository;
using SaveApp.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Services.WorkoutRoutineService
{
    public class WorkoutRoutineCommandService : IWorkoutRoutineCommandService
    {
        private readonly IWorkoutRoutineCommandRepository _commandRepository;
        private readonly IWorkoutQueryService _workoutQueryService;

        public WorkoutRoutineCommandService(
            IWorkoutRoutineCommandRepository commandRepository,
            IWorkoutQueryService workoutQueryService
        )
        {
            _commandRepository = commandRepository;
            _workoutQueryService = workoutQueryService;
        }

        public int Create()
        {
            return _commandRepository.Create();
        }

        public int CreateWithInput(int workoutId)
        {
            WorkoutDetails workout = _workoutQueryService.GetByWorkoutId(workoutId);

            List<WorkoutRoutineExercise> routineExercises = workout.Exercises!.Select(o => 
                new WorkoutRoutineExercise {
                    Exercise = o.Exercise,
                    Notes = string.Empty,
                    NumberOfSets = o.ExerciseSets != null ? o.ExerciseSets.Count : 0
                }).ToList();

            WorkoutRoutine routine =
                new()
                {
                    Name = workout.Name,
                    Notes = workout.Notes,
                    WorkoutRoutineExercises = routineExercises
                };

            return _commandRepository.CreateWithInput(routine);
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
