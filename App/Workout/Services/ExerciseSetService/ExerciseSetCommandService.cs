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
            ExerciseSet set = new();
            set.Notes = string.Empty;
            set.Reps = 0;
            set.Weight = 0;
            WorkoutExercise workoutExercise = _workoutQueryRepository.GetLatestWorkoutExerciseById(
                input.UserId,
                input.WorkoutExerciseId,
                input.ExerciseId
            );

            if (
                workoutExercise != null
                && input.IndexOfSet != 0
                && workoutExercise != null
                && workoutExercise.ExerciseSets != null
                && input.IndexOfSet <= workoutExercise.ExerciseSets.Count - 1
            )
            {
                set.Weight = workoutExercise.ExerciseSets[input.IndexOfSet].Weight;
                set.Reps = workoutExercise.ExerciseSets[input.IndexOfSet].Reps;
                set.Notes = workoutExercise.ExerciseSets[input.IndexOfSet].Notes;
            }

            ExerciseSet createdSet = _commandRepository.Create(set, input.ExerciseId, input.WorkoutExerciseId, input.UserId);

            if (
                workoutExercise != null
                && input.IndexOfSet != 0
                && workoutExercise != null
                && workoutExercise.ExerciseSets != null
                && input.IndexOfSet <= workoutExercise.ExerciseSets.Count - 1
            )
            {
                createdSet.ExerciseSetPreviousValues = _mapper.Map<ExerciseSetPreviousValues>(
                    workoutExercise.ExerciseSets[input.IndexOfSet]
                );
            }

            return createdSet;
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
