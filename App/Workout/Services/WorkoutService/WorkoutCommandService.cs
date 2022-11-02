using SaveApp.App.Workout.Models;
using sports_application.App.Workout.Repositories.WorkoutRepository;

namespace sports_application.App.Workout.Services.WorkoutService
{
    public class WorkoutCommandService : IWorkoutCommandService
    {
        private readonly IWorkoutCommandRepository _commandRepository;
    
        public WorkoutCommandService(IWorkoutCommandRepository commandRepository) {
            _commandRepository = commandRepository;
        }
        public void Create(int userId, WorkoutDetails workoutDetails) {
            _commandRepository.Create(userId, workoutDetails);
        }
        
    }
}