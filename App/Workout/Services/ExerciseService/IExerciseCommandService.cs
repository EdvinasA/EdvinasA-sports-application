using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Services
{
    public interface IExerciseCommandService
    {
         void CreateExercise(Exercise exercise);
         void UpdateExercise(Exercise exercise);
         List<ExerciseEntity> GetAllExercises();
    }
}