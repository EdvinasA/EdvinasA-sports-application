using SaveApp.App.Workout.Models;

namespace sports_application.App.Workout.Services.WorkoutService
{
    public interface IWorkoutQueryService
    {
        List<WorkoutDetails> GetAllByUserId(int UserId);
        
    }
}