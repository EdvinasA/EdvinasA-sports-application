using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public interface IExerciseCommandRepository
    {
        Exercise Create(ExerciseCreateInput input);
        void Update(Exercise input);
        void Delete(int exerciseId);
    }
}
