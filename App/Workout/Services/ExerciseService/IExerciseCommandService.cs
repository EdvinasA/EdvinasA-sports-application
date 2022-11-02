using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Services
{
    public interface IExerciseCommandService
    {
         void CreateExercise(int userId, Exercise exercise);
         void UpdateExercise(int userId, Exercise exercise);
         List<ExerciseEntity> GetAllExercises(int userId);
    }
}