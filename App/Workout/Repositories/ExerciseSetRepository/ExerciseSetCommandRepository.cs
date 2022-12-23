using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public class ExerciseSetCommandRepository : IExerciseSetCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseSetCommandRepository(
            ExerciseContext context,
            ILogger<string> logger,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() =>
            int.Parse(
                _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

        public ExerciseSet Create(ExerciseSet input, int exerciseId, int workoutExerciseId)
        {
            _logger.LogInformation(input.ToString());
            ExerciseSetEntity entity = _mapper.Map<ExerciseSetEntity>(input);
            entity.ExerciseEntity = _context.Exercise?.Find(exerciseId);
            entity.WorkoutExerciseEntity = _context.WorkoutExercise?.Find(workoutExerciseId);
            entity.UserEntity = _context.User?.Find(GetUserId());

            _context.ExerciseSet?.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<ExerciseSet>(entity);
        }

        public void CreateSetForRoutine(ExerciseSet input, int exerciseId, int workoutExerciseId) 
        {
            ExerciseSetEntity entity = _mapper.Map<ExerciseSetEntity>(input);
            entity.ExerciseEntity = _context.Exercise?.Find(exerciseId);
            entity.WorkoutExerciseEntity = _context.WorkoutExercise?.Find(workoutExerciseId);
            entity.UserEntity = _context.User?.Find(GetUserId());

            _context.ExerciseSet?.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int exerciseSetId)
        {
            ExerciseSetEntity entity = _context.ExerciseSet.FirstOrDefault(
                dc => dc.Id == exerciseSetId
            );

            _context.ExerciseSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ExerciseSet exerciseSet)
        {
            ExerciseSetEntity entity = _context.ExerciseSet.Find(exerciseSet.Id);

            entity.Notes = exerciseSet.Notes;
            entity.Weight = exerciseSet.Weight;
            entity.Reps = exerciseSet.Reps;
            entity.UserEntity = _context.User!.Find(GetUserId());

            _context.ExerciseSet.Update(entity);
            _context.SaveChanges();
        }

        public ExerciseSet CopySet(int setId) {
            ExerciseSetEntity entity = 
                _context.ExerciseSet!
                .Include("ExerciseEntity")
                .Include("WorkoutExerciseEntity")
                .Include("UserEntity")
                .Where(o => o.Id == setId)
                .Single();

            ExerciseSetEntity entityCopy = new ExerciseSetEntity {
                Weight = entity.Weight,
                Reps = entity.Reps,
                Notes = entity.Notes,
                ExerciseEntity = entity.ExerciseEntity,
                WorkoutExerciseEntity = entity.WorkoutExerciseEntity,
                UserEntity = entity.UserEntity
            };

            _context.ExerciseSet!.Add(entityCopy);
            _context.SaveChanges();

            return _mapper.Map<ExerciseSet>(entityCopy);
        }
    }
}
