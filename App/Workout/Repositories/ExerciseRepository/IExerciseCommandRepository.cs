using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public interface IExerciseCommandRepository
    {
         void Create(int userId, Exercise input);
    }
}