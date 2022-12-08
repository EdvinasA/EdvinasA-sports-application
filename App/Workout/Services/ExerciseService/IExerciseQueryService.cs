using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseService
{
    public interface IExerciseQueryService
    {
        List<Exercise> GetAllExercises();
        List<Exercise> GetExercisesByCategory(int categoryId);
    }
}
