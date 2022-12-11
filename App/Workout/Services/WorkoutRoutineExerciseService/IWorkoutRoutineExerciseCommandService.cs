using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutRoutineExerciseService
{
    public interface IWorkoutRoutineExerciseCommandService
    {
        WorkoutRoutineExercise CreateForWorkoutRoutine(AddExerciseToRoutineInput input);
        void Update(WorkoutRoutineExercise input);
        void Delete(int workoutRoutineExerciseId);
    }
}