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

        public ExerciseQueryRepository(ExerciseContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<Exercise> GetExercises(int userId) {
            List<ExerciseEntity> entities = _context.Exercise
            .Where(e => e.User.Id == userId)
            .ToList();

            return entities.Select(e => _mapper.Map<Exercise>(e)).ToList();
        }
    }
}