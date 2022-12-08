using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public interface IExerciseQueryRepository
    {
        List<Exercise> GetExercises();
        List<Exercise> GetExercisesByCategory(int categoryId);
    }
}
