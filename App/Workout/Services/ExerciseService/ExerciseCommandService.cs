using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Converters;

namespace SaveApp.App.Workout.Services
{
    public class ExerciseCommandService : IExerciseCommandService
    {
        private readonly ExerciseConverter _converter;

        public ExerciseCommandService(ExerciseConverter converter) {
        _converter = converter;
        }

        public void CreateExercise(Exercise exercise) 
        {
            var result = _converter.ConvertToEntity(exercise);

            Console.WriteLine(result);
        }

        public void UpdateExercise(Exercise exercise) 
        {

        }
    }
}