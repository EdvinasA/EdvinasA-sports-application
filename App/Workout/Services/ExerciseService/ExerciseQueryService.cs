using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseRepository;

namespace SaveApp.App.Workout.Services.ExerciseService
{
    public class ExerciseQueryService : IExerciseQueryService
    {
        private readonly IExerciseQueryRepository _queryRepository;

        public ExerciseQueryService(IExerciseQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public List<Exercise> GetAllExercises(int userId)
        {
            return _queryRepository.GetExercises(userId);
        }

        public List<Exercise> GetExercisesByCategory(int userId, int categoryId)
        {
            return _queryRepository.GetExercisesByCategory(userId, categoryId);
        }
    }
}
