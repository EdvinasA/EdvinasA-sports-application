using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.Converters
{
    public class ExerciseConverter
    {
        public ExerciseEntity ConvertToEntity(Exercise input) {
            var result = new ExerciseEntity();
            result.Id = input.Id;
            result.Name = input.Name;
            
            return result;
        }
    }
}