using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseRepository;

namespace SaveApp.App.Workout.Services.ExerciseService
{
    public class ExerciseQueryService : IExerciseQueryService
    {

        private readonly IExerciseQueryRepository _queryRepository;

        public ExerciseQueryService(IExerciseQueryRepository queryRepository) {
            _queryRepository = queryRepository;
        }
        public List<Exercise> GetExercisesByBodyPart(int userId, ExerciseBodyPart exerciseBodyPart) {
            return _queryRepository.GetExercisesByBodyPart(userId, exerciseBodyPart);
        }
        
    }
}