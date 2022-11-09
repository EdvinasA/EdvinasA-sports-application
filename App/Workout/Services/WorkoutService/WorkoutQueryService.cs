using SaveApp.App.Workout.Models;
using sports_application.App.Workout.Repositories.WorkoutRepository;

namespace sports_application.App.Workout.Services.WorkoutService
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
        
    }
}