using System.Security.Claims;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public class ExerciseQueryRepository : IExerciseQueryRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseQueryRepository(ExerciseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public List<Exercise> GetExercises()
        {
            List<ExerciseEntity> entities = _context.Exercise
                .Where(e => e.User.Id == GetUserId())
                .ToList();

            return entities.Select(e => _mapper.Map<Exercise>(e)).ToList();
        }

        public List<Exercise> GetExercisesByCategory(int categoryId)
        {
            List<ExerciseEntity> entities = _context.Exercise
                .Where(e => e.User.Id == GetUserId())
                .Where(e => e.ExerciseCategoryId == categoryId)
                .ToList();

            return entities.Select(e => _mapper.Map<Exercise>(e)).ToList();
        }
    }
}
