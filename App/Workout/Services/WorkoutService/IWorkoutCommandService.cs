using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutCommandService
    {
        int Create(int userId);
        WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise);
        void Update(int userId, WorkoutDetailsUpdateInput workoutDetails);
        void DeleteWorkoutExercise(int userId, int workoutExerciseId);
        void DeleteWorkout(int userId, int workoutId);
    }
}
