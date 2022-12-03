using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseCategoryService
{
    public interface IExerciseCategoryQueryService
    {
        List<ExerciseCategory> GetByUserId(int userId);
    }
}
