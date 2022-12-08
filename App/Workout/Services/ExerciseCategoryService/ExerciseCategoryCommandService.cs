using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseCategoryRepository;
using SaveApp.App.Workout.Repositories.ExerciseRepository;

namespace SaveApp.App.Workout.Services.ExerciseCategoryService
{
    public class ExerciseCategoryCommandService : IExerciseCategoryCommandService
    {
        private readonly IExerciseCategoryCommandRepository _commandRepository;

        public ExerciseCategoryCommandService(IExerciseCategoryCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public ExerciseCategory Create(ExerciseCategory input)
        {
            return _commandRepository.Create(input);
        }

        public void Update(ExerciseCategory input)
        {
            _commandRepository.Update(input);
        }

        public void Delete(int categoryId)
        {
            _commandRepository.Delete(categoryId);
        }
    }
}
