using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutRoutineExerciseService
{
    public class WorkoutRoutineExerciseCommandService : IWorkoutRoutineExerciseCommandService
    {
        private readonly IWorkoutRoutineExerciseCommandService _commandService;

        public WorkoutRoutineExerciseCommandService(IWorkoutRoutineExerciseCommandService commandService) {
            _commandService = commandService;
        }

        public WorkoutRoutineExercise CreateForWorkoutRoutine(int ExerciseId)
        {
            return _commandService.CreateForWorkoutRoutine(ExerciseId);
        }

        public void Delete(int workoutRoutineExerciseId)
        {
            _commandService.Delete(workoutRoutineExerciseId);
        }

        public void Update(WorkoutRoutineExercise input)
        {
            _commandService.Update(input);
        }
    }
}