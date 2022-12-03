using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseCategoryRepository;

namespace SaveApp.App.Workout.Services.ExerciseCategoryService
{
    public class ExerciseCategoryQueryService : IExerciseCategoryQueryService
    {
        private readonly IExerciseCategoryQueryRepository _queryRepository;

        public ExerciseCategoryQueryService(IExerciseCategoryQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public List<ExerciseCategory> GetByUserId(int userId)
        {
            return _queryRepository.GetByUserId(userId);
        }
    }
}
