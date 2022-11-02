using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public interface IExerciseCommandRepository
    {
         void Create(Exercise input);
    }
}