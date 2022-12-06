using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRepository;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutQueryService : IWorkoutQueryService
    {
        private readonly IWorkoutQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public WorkoutQueryService(IWorkoutQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public List<WorkoutDetails> GetAllByUserId(int UserId)
        {
            return _queryRepository.GetWorkouts(UserId);
        }

        public WorkoutDetails GetByWorkoutId(int userId, int workoutId)
        {
            WorkoutDetails workoutDetails = _queryRepository.GetWorkout(userId, workoutId);

            if (workoutDetails == null || workoutDetails.Exercises == null || workoutDetails.Exercises.Count == 0)
            {
                return workoutDetails;
            }

            foreach (var workoutExercise in workoutDetails.Exercises)
            {
                if (workoutExercise.ExerciseSets == null || workoutExercise.ExerciseSets.Count == 0)
                {
                    continue;
                }

                WorkoutExercise workoutExerciseFromDb =
                    _queryRepository.GetLatestWorkoutExerciseById(
                        userId,
                        (int)workoutExercise.Id,
                        workoutExercise.Exercise.Id
                    );

                if (workoutExerciseFromDb == null)
                {
                    continue;
                }

                if (workoutExerciseFromDb.ExerciseSets == null)
                {
                    continue;
                }

                for (var i = 0; i < workoutExerciseFromDb.ExerciseSets.Count; i++)
                {
                    workoutExercise.ExerciseSets[i].ExerciseSetPreviousValues =
                        _mapper.Map<ExerciseSetPreviousValues>(
                            workoutExerciseFromDb.ExerciseSets[i]
                        );
                }
            }
            return workoutDetails;
        }

        public WorkoutExercise GetLatestWorkoutExerciseById(int userId, int currentWorkoutExerciseId, int exerciseId)
        {
            return _queryRepository.GetLatestWorkoutExerciseById(userId, currentWorkoutExerciseId ,exerciseId);
        }
    }
}
