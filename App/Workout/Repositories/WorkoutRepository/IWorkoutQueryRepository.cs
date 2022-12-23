using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutQueryRepository
    {
        List<WorkoutDetails> GetWorkouts();
        WorkoutDetails GetWorkout(int workoutId);
        WorkoutExercise GetLatestWorkoutExerciseById(int currentWorkoutExerciseId, int exerciseId);
        List<WorkoutExercise> GetWorkoutsByExerciseId(int exerciseId);
        WorkoutDetails GetWorkoutByExerciseIdWithBestWeight(int exerciseId);
    }
}
