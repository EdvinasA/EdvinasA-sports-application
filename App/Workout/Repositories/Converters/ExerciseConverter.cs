using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;
using sports_application.App.Workout.Repositories.Converters;

namespace SaveApp.App.Workout.Repositories.Converters
{
    public class ExerciseConverter : IExerciseConverter
    {
        public ExerciseEntity ConvertToEntity(Exercise input) {
            var result = new ExerciseEntity();
            result.Name = input.Name;
            
            return result;
        }

        public Exercise ConvertFromEntity(ExerciseEntity input) {
            return null;
        }
    }
}