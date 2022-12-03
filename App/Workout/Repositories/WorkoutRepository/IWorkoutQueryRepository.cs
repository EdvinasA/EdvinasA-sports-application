using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutQueryRepository
    {
        List<WorkoutDetails> GetWorkouts(int UserId);
        WorkoutDetails GetWorkout(int userId, int workoutId);
        WorkoutExercise GetLatestWorkoutExerciseById(int userId, int exerciseId);
    }
}
