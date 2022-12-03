using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public interface IExerciseQueryRepository
    {
        List<Exercise> GetExercises(int userId);
        List<Exercise> GetExercisesByCategory(int userId, int categoryId);
    }
}
