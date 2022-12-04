using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Repositories.WorkoutRepository;
using SaveApp.App.Workout.Services.ExerciseSetService;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutCommandService : IWorkoutCommandService
    {
        private readonly IWorkoutCommandRepository _commandRepository;
        private readonly IExerciseSetCommandService _exerciseSetCommandService;
        private readonly ILogger _logger;

        public WorkoutCommandService(
            IWorkoutCommandRepository commandRepository,
            IExerciseSetCommandService exerciseSetCommandService,
            ILogger<string> logger
        )
        {
            _commandRepository = commandRepository;
            _exerciseSetCommandService = exerciseSetCommandService;
            _logger = logger;
        }

        public int Create(int userId)
        {
            return _commandRepository.Create(
                userId,
                new WorkoutDetailsCreateInput()
                {
                    Date = DateTime.UtcNow,
                    StartTime = DateTime.UtcNow
                }
            );
        }

        public WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise)
        {
            WorkoutExercise addedExercise = _commandRepository.AddExerciseToWorkout(
                userId,
                exercise
            );

            ExerciseSetCreateInput set = new ExerciseSetCreateInput();
            set.Weight = 0;
            set.Reps = 0;
            set.ExerciseId = exercise.Exercise.Id;
            set.WorkoutExerciseId = addedExercise.Id;
            set.UserId = userId;

            ExerciseSet createdSet = _exerciseSetCommandService.Create(set);

            addedExercise.ExerciseSets!.Add(createdSet);

            return addedExercise;
        }

        public void Update(int userId, WorkoutDetailsUpdateInput workoutDetails)
        {
            _commandRepository.Update(userId, workoutDetails);
        }

        public void DeleteWorkoutExercise(int userId, int workoutExerciseId)
        {
            _commandRepository.DeleteWorkoutExercise(userId, workoutExerciseId);
        }

        public void DeleteWorkout(int userId, int workoutId)
        {
            _commandRepository.DeleteWorkout(userId, workoutId);
        }
    }
}
