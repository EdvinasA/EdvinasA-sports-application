using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutQueryRepository
    {
        List<WorkoutDetails> GetWorkouts(int UserId);
    }
}