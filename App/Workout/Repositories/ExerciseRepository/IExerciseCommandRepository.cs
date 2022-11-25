using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public interface IExerciseCommandRepository
    {
         Exercise Create(int userId, ExerciseCreateInput input);
         void Update(int userId, Exercise input);
    }
}