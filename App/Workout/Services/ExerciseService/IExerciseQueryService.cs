using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseService
{
    public interface IExerciseQueryService
    {
        List<Exercise> GetAllExercises(int userId);
        List<Exercise> GetExercisesByCategory(int userId, int categoryId);
    }
}