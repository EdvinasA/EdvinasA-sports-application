using System.Security.Claims;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseCategoryRepository
{
    public class ExerciseCategoryQueryRepository : IExerciseCategoryQueryRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseCategoryQueryRepository(ExerciseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public List<ExerciseCategory> GetByUserId()
        {
            List<ExerciseCategoryEntity> entities = _context.ExerciseCategories!
                .Where(entity => entity.User!.Id == GetUserId())
                .ToList();

            return entities.Select(entity => _mapper.Map<ExerciseCategory>(entity)).ToList();
        }
    }
}
