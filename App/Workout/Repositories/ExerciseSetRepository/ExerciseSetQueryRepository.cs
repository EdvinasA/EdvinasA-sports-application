using System.Security.Claims;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public class ExerciseSetQueryRepository : IExerciseSetQueryRepository
    {
        private readonly ExerciseContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseSetQueryRepository(
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

        public List<ExerciseSet> GetHitoryOfExerciseSets(int workoutExerciseId, int exerciseId)
        {
            List<ExerciseSetEntity> entities = _context.ExerciseSet!
                .Where(o => o.UserEntity!.Id == GetUserId())
                .Where(o => o.WorkoutExerciseEntity!.Id != workoutExerciseId)
                .ToList();

            return entities.Select(o => _mapper.Map<ExerciseSet>(o)).ToList();
        }
    }
}
