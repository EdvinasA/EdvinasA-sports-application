using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkoutQueryRepository(
            ILogger<string> logger,
            ExerciseContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public List<WorkoutDetails> GetWorkouts()
        {
            List<WorkoutEntity> entities = _context.Workout!
                .Include("Exercises.Exercise")
                .Include("Exercises.ExerciseSets")
                .Where(workout => workout.UserEntity!.Id == GetUserId())
                .OrderByDescending(workout => workout.Date)
                .ToList();

            return entities.Select(entity => _mapper.Map<WorkoutDetails>(entity)).ToList();
        }

        public WorkoutDetails GetWorkout(int workoutId)
        {
            return _mapper.Map<WorkoutDetails>(
                _context.Workout
                    .Include("Exercises.Exercise")
                    .Include("Exercises.ExerciseSets")
                    .Where(workout => workout.Id == workoutId)
                    .Single()
            );
        }

        public List<WorkoutExercise> GetWorkoutsByExerciseId(int exerciseId)
        {
            List<WorkoutExerciseEntity> entities = _context.WorkoutExercise!
                    .Include("Exercise")
                    .Include("ExerciseSets")
                    .Where(exercise => exercise.User!.Id == GetUserId())
                    .Where(exercise => exercise.Exercise!.Id == exerciseId)
                    .ToList();

            return entities.Select(o => _mapper.Map<WorkoutExercise>(o)).ToList();
        }

        public WorkoutExercise GetLatestWorkoutExerciseById(int currentWorkoutExerciseId, int exerciseId)
        {
            WorkoutExerciseEntity exerciseEntityToGetDate = _context.WorkoutExercise!.Include("WorkoutEntity").Where(o => o.Id == currentWorkoutExerciseId).Single();
            List<WorkoutExerciseEntity> entity = _context.WorkoutExercise
                .Include("Exercise")
                .Include("ExerciseSets")
                .Include("User")
                .Where(o => o.User!.Id == GetUserId())
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
