using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public class ExerciseSetCommandService : IExerciseSetCommandService
    {
        private readonly IExerciseSetCommandRepository _commandRepository;
        
        public ExerciseSetCommandService(IExerciseSetCommandRepository commandRepository) {
            _commandRepository = commandRepository;
        }

        public ExerciseSet Create(ExerciseSetCreateInput input) {
            return _commandRepository.Create(input);
        }

        public void Delete(int exerciseSetId) {
            _commandRepository.Delete(exerciseSetId);
        }

        public void Update(int userId, ExerciseSet exerciseSet) {
            _commandRepository.Update(userId, exerciseSet);
        }
    }
}