using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutQueryService
    {
        List<WorkoutDetails> GetAllByUserId(int UserId);
        
    }
}