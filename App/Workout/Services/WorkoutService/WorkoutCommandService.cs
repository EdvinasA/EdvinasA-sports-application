using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Repositories.WorkoutRepository;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutCommandService : IWorkoutCommandService
    {
        private readonly IWorkoutCommandRepository _commandRepository;
    
        public WorkoutCommandService(IWorkoutCommandRepository commandRepository) {
            _commandRepository = commandRepository;
        }
        public int Create(int userId) {
            return _commandRepository.Create(userId, new WorkoutDetailsCreateInput() {
                Date = DateTime.UtcNow,
                StartTime = DateTime.UtcNow
            });
        }
        
        public WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise) {
            return _commandRepository.AddExerciseToWorkout(userId, exercise);
        }

        public void Update(int userId, WorkoutDetailsUpdateInput workoutDetails) {
            _commandRepository.Update(userId, workoutDetails);
        }

        public void DeleteWorkoutExercise(int userId, int workoutExerciseId) {
            _commandRepository.DeleteWorkoutExercise(userId, workoutExerciseId);
        }

        public void DeleteWorkout(int userId, int workoutId) {
            _commandRepository.DeleteWorkout(userId, workoutId);
        }
    }
}