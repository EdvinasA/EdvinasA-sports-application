using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseCategoryService
{
    public interface IExerciseCategoryCommandService
    {
         ExerciseCategory Create(int userId, ExerciseCategory input);
    }
}