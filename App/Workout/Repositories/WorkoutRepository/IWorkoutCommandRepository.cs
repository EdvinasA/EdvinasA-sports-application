using SaveApp.App.Workout.Models;

namespace sports_application.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutCommandRepository
    {
         void Create(int userId, WorkoutDetails input);
    }
}