using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutQueryService
    {
        List<WorkoutDetails> GetAllByUserId(int UserId);
        
    }
}