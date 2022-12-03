using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseCategoryRepository
{
    public interface IExerciseCategoryQueryRepository
    {
        List<ExerciseCategory> GetByUserId(int userId);
    }
}
