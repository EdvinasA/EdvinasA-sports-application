using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public class WorkoutQueryRepository : IWorkoutQueryRepository
    {
        private readonly ILogger _logger;
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public WorkoutQueryRepository(
            ILogger<string> logger,
            ExerciseContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<WorkoutDetails> GetWorkouts(int userId)
        {
            List<WorkoutEntity> entities = _context.Workout!
                .Include("Exercises.Exercise")
                .Include("Exercises.ExerciseSets")
                .Where(workout => workout.UserEntity!.Id == userId)
                .OrderByDescending(workout => workout.Date)
                .ToList();

            return entities.Select(entity => _mapper.Map<WorkoutDetails>(entity)).ToList();
        }

        public WorkoutDetails GetWorkout(int userId, int workoutId)
        {
            return _mapper.Map<WorkoutDetails>(
                _context.Workout
                    .Include("Exercises.Exercise")
                    .Include("Exercises.ExerciseSets")
                    .Where(workout => workout.Id == workoutId)
                    .Single()
            );
        }

        public WorkoutExercise GetLatestWorkoutExerciseById(int userId, int currentWorkoutExerciseId, int exerciseId)
        {
            WorkoutExerciseEntity exerciseEntityToGetDate = _context.WorkoutExercise!.Include("WorkoutEntity").Where(o => o.Id == currentWorkoutExerciseId).Single();
            List<WorkoutExerciseEntity> entity = _context.WorkoutExercise
                .Include("Exercise")
                .Include("ExerciseSets")
                .Include("User")
                .Where(o => o.User!.Id == userId)
                .Where(o => o.Exercise!.Id == exerciseId)
                .Where(o => o.Id != currentWorkoutExerciseId)
                .Where(o => DateTime.Compare(o.WorkoutEntity.Date, exerciseEntityToGetDate.WorkoutEntity.Date) < 0)
                .ToList();

                if (entity.Count == 0) {
                    return null;
                }

            return _mapper.Map<WorkoutExercise>(entity.MaxBy(o => o.Id));
        }
    }
}
