using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseCategoryRepository
{
    public interface IExerciseCategoryCommandRepository
    {
        ExerciseCategory Create(int userId, ExerciseCategory input);
        void Update(int userId, ExerciseCategory input);
         
    }
}