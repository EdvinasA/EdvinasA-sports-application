using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services
{
    public interface IExerciseCommandService
    {
         void CreateExercise(Exercise exercise);
         void UpdateExercise(Exercise exercise);
    }
}