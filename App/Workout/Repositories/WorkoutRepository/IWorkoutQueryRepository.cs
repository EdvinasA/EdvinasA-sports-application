using SaveApp.App.Workout.Models;

namespace sports_application.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutQueryRepository
    {
        List<WorkoutDetails> GetWorkouts(int UserId);
    }
}