using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRepository;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutQueryService : IWorkoutQueryService
    {
        private readonly IWorkoutQueryRepository _queryRepository;

        public WorkoutQueryService(IWorkoutQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public List<WorkoutDetails> GetAllByUserId(int UserId)
        {
            return _queryRepository.GetWorkouts(UserId);
        }

        public WorkoutDetails GetByWorkoutId(int userId, int workoutId)
        {
            WorkoutDetails workoutDetails = _queryRepository.GetWorkout(userId, workoutId);

            if (workoutDetails.Exercises == null || workoutDetails.Exercises.Count() == 0)
            {
                return workoutDetails;
            }

            foreach (var workoutExercise in workoutDetails.Exercises)
            {
                if (
                    workoutExercise.ExerciseSets == null
                    || workoutExercise.ExerciseSets.Count() == 0
                )
                {
                    continue;
                }

                WorkoutExercise workoutExerciseFromDb =
                    _queryRepository.GetLatestWorkoutExerciseById(
                        userId,
                        workoutExercise.Exercise.Id
                    );
                for (var i = 0; i < workoutExercise.ExerciseSets.Count(); i++)
                {
                    workoutExercise.ExerciseSets[i] = workoutExerciseFromDb.ExerciseSets[i];
                }
            }
            return workoutDetails;
        }

        public WorkoutExercise GetLatestWorkoutExerciseById(int userId, int exerciseId)
        {
            return _queryRepository.GetLatestWorkoutExerciseById(userId, exerciseId);
        }
    }
}
