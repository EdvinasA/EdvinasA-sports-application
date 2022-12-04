using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutQueryService
    {
        List<WorkoutDetails> GetAllByUserId(int UserId);
        WorkoutDetails GetByWorkoutId(int userId, int workoutId);
        WorkoutExercise GetLatestWorkoutExerciseById(int userId, int currentWorkoutExerciseId, int exerciseId);
    }
}
