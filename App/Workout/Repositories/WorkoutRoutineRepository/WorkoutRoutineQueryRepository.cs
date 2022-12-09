using System.Security.Claims;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.WorkoutRoutineRepository
{
    public class WorkoutRoutineQueryRepository : IWorkoutRoutineQueryRepository
    {
        private readonly ExerciseContext _context;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WorkoutRoutineQueryRepository(
            ExerciseContext context,
            ILogger<string> logger,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        private int GetUserId() =>
            int.Parse(
                _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

        public List<WorkoutRoutine> GetAll() {
            List<WorkoutRoutineEntity> entities = _context.WorkoutRoutine!.Where(o => o.User!.Id == GetUserId()).ToList();

            return entities.Select(o => _mapper.Map<WorkoutRoutine>(o)).ToList();
        }

         public WorkoutRoutine GetById(int workoutRoutineId) {
            WorkoutRoutineEntity entity = _context.WorkoutRoutine!
            .Where(o => o.User!.Id == GetUserId())
            .Where(o => o.Id == workoutRoutineId)
            .Single();

            return _mapper.Map<WorkoutRoutine>(entity);
         }
        
    }
}