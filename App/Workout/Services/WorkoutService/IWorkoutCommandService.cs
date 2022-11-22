using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutCommandService
    {
         void Create(int userId);
         WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise);
         void Update(int userId, WorkoutDetailsUpdateInput workoutDetails);
    }
}