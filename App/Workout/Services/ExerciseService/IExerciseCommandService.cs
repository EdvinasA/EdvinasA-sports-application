using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Services
{
    public interface IExerciseCommandService
    {
         Exercise CreateExercise(int userId, ExerciseCreateInput exercise);
         void UpdateExercise(int userId, Exercise exercise);
    }
}