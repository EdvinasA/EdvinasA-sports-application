using SaveApp.App.Workout.Models;

namespace sports_application.App.Workout.Services.WorkoutService
{
    public interface IWorkoutCommandService
    {
         void Create(int userId, WorkoutDetails workoutDetails);
    }
}