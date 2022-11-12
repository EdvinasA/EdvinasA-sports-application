using SaveApp.App.Workout.Repositories.ExerciseSetRepository;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public class ExerciseSetCommandService : IExerciseSetCommandService
    {
        private readonly ExerciseSetCommandRepository _commandRepository;
        
        public ExerciseSetCommandService(ExerciseSetCommandRepository commandRepository) {
            _commandRepository = commandRepository;
        }

        public int Create() {
            return 1;
        }
    }
}