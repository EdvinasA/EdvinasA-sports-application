using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutQueryService
    {
        List<WorkoutDetails> GetAllByUserId();
        WorkoutDetails GetByWorkoutId(int workoutId);
        WorkoutExercise GetLatestWorkoutExerciseById(int currentWorkoutExerciseId, int exerciseId);
        List<WorkoutExercise> GetWorkoutsByExerciseId(int exerciseId);
    }
}
