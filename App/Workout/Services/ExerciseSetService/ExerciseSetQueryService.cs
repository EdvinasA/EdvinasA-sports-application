using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public class ExerciseSetQueryService : IExerciseSetQueryService
    {
        private readonly IExerciseSetQueryRepository _queryRepository;

        public ExerciseSetQueryService(IExerciseSetQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public List<ExerciseSet> GetHitoryOfExerciseSets(int workoutExerciseId, int exerciseId)
        {
            return _queryRepository.GetHitoryOfExerciseSets(workoutExerciseId, exerciseId);
        }
    }
}
