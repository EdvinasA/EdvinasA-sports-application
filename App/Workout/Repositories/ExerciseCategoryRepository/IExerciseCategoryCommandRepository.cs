using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseCategoryRepository
{
    public interface IExerciseCategoryCommandRepository
    {
        ExerciseCategory Create(ExerciseCategory input);
        void Update(ExerciseCategory input);
        void Delete(int categoryId);
    }
}
