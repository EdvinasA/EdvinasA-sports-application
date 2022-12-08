using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Services
{
    public interface IExerciseCommandService
    {
        Exercise CreateExercise(ExerciseCreateInput exercise);
        void UpdateExercise(Exercise exercise);
        void Delete(int exerciseId);
    }
}
