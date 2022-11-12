using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.Converters
{
    public interface IExerciseConverter
    {
         ExerciseEntity ConvertToEntity(Exercise input);
         Exercise ConvertFromEntity(ExerciseEntity input);
    }
}