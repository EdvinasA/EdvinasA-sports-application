using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace sports_application.App.Workout.Repositories.WorkoutRepository
{
    public class WorkoutQueryRepository : IWorkoutQueryRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public WorkoutQueryRepository(ExerciseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<WorkoutDetails> GetWorkouts(int UserId) {
            List<WorkoutEntity> entities = _context.Workout.Where(Workout => Workout.UserEntity.Id == UserId).ToList();

            return entities.Select(entity => _mapper.Map<WorkoutDetails>(entity)).ToList();
        }
    }
}