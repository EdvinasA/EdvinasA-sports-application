using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRepository;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutQueryService : IWorkoutQueryService
    {
        private readonly IWorkoutQueryRepository _queryRepository;

        public WorkoutQueryService(IWorkoutQueryRepository queryRepository) {
            _queryRepository = queryRepository;
        }

        public List<WorkoutDetails> GetAllByUserId(int UserId) {
            return _queryRepository.GetWorkouts(UserId);
        }

        public WorkoutDetails GetByWorkoutId(int userId, int workoutId) {
            return _queryRepository.GetWorkout(userId, workoutId);
        }
        
    }
}