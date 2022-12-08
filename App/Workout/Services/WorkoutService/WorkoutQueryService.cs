using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRepository;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public class WorkoutQueryService : IWorkoutQueryService
    {
        private readonly IWorkoutQueryRepository _queryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public WorkoutQueryService(
            IWorkoutQueryRepository queryRepository,
            IMapper mapper,
            ILogger<string> logger
        )
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public List<WorkoutDetails> GetAllByUserId()
        {
            return _queryRepository.GetWorkouts();
        }

        public WorkoutDetails GetByWorkoutId(int workoutId)
        {
            WorkoutDetails workoutDetails = _queryRepository.GetWorkout(workoutId);

            if (
                workoutDetails == null
                || workoutDetails.Exercises == null
                || workoutDetails.Exercises.Count == 0
            )
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

                for (var i = 0; i < workoutExercise.ExerciseSets.Count; i++)
                {
                    if (i > workoutExerciseFromDb.ExerciseSets.Count - 1)
                    {
                        break;
                    }

                    workoutExercise.ExerciseSets[i].ExerciseSetPreviousValues =
                        _mapper.Map<ExerciseSetPreviousValues>(
                            workoutExerciseFromDb.ExerciseSets[i]
                        );
                }
            }
            return workoutDetails;
        }

        public WorkoutExercise GetLatestWorkoutExerciseById(
            int currentWorkoutExerciseId,
            int exerciseId
        )
        {
            return _queryRepository.GetLatestWorkoutExerciseById(
                currentWorkoutExerciseId,
                exerciseId
            );
        }
    }
}
