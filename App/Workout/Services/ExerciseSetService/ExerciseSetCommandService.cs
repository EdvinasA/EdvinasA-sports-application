using AutoMapper;
using Microsoft.Extensions.Logging;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Repositories.WorkoutRepository;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public class ExerciseSetCommandService : IExerciseSetCommandService
    {
        private readonly ILogger _logger;
        private readonly IExerciseSetCommandRepository _commandRepository;
        private readonly IWorkoutQueryRepository _workoutQueryRepository;
        private readonly IMapper _mapper;

        public ExerciseSetCommandService(
            ILogger<string> logger,
            IExerciseSetCommandRepository commandRepository,
            IWorkoutQueryRepository workoutQueryRepository,
            IMapper mapper
        )
        {
            _logger = logger;
            _commandRepository = commandRepository;
            _workoutQueryRepository = workoutQueryRepository;
            _mapper = mapper;
        }

        public ExerciseSet Create(ExerciseSetCreateInput input)
        {
            ExerciseSet set = _commandRepository.Create(input);
            WorkoutExercise workoutExercise = _workoutQueryRepository.GetLatestWorkoutExerciseById(
                input.UserId,
                input.WorkoutExerciseId,
                input.ExerciseId
            );

            if (workoutExercise != null && input.IndexOfSet != 0 && input.IndexOfSet < workoutExercise.ExerciseSets.Count)
            {
                set.ExerciseSetPreviousValues = _mapper.Map<ExerciseSetPreviousValues>(
                    workoutExercise.ExerciseSets[input.IndexOfSet]
                );
            }

            return set;
        }

        public void Delete(int exerciseSetId)
        {
            _commandRepository.Delete(exerciseSetId);
        }

        public void Update(int userId, ExerciseSet exerciseSet)
        {
            _commandRepository.Update(userId, exerciseSet);
        }
    }
}
