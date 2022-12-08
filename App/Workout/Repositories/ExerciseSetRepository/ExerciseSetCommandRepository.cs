using System.Security.Claims;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public class ExerciseSetCommandRepository : IExerciseSetCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseSetCommandRepository(ExerciseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public ExerciseSet Create(ExerciseSet input, int exerciseId, int workoutExerciseId)
        {
            ExerciseSetEntity entity = _mapper.Map<ExerciseSetEntity>(input);
            entity.ExerciseEntity = _context.Exercise?.Find(exerciseId);
            entity.WorkoutExerciseEntity = _context.WorkoutExercise?.Find(workoutExerciseId);
            entity.UserEntity = _context.User?.Find(GetUserId());

            _context.ExerciseSet?.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<ExerciseSet>(entity);
        }

        public void Delete(int exerciseSetId) {
            ExerciseSetEntity entity = _context.ExerciseSet.FirstOrDefault(dc => dc.Id == exerciseSetId);

            _context.ExerciseSet.Remove(entity);
            _context.SaveChanges();
        }
 
        public void Update(ExerciseSet exerciseSet) {
            ExerciseSetEntity entity = _context.ExerciseSet.Find(exerciseSet.Id);

            entity.Notes = exerciseSet.Notes;
            entity.Weight = exerciseSet.Weight;
            entity.Reps = exerciseSet.Reps;
            entity.UserEntity = _context.User!.Find(GetUserId());

            _context.ExerciseSet.Update(entity);
            _context.SaveChanges();
        }
    }
}