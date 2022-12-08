using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseCategoryService
{
    public interface IExerciseCategoryCommandService
    {
        ExerciseCategory Create(ExerciseCategory input);
        void Update(ExerciseCategory input);
        void Delete(int categoryId);
    }
}
