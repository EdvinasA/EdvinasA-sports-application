using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace sports_application.App.Workout.Repositories.Converters
{
    public interface IExerciseConverter
    {
         ExerciseEntity ConvertToEntity(Exercise input);
         Exercise ConvertFromEntity(ExerciseEntity input);
    }
}