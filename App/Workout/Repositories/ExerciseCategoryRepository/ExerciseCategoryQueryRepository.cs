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

        public ExerciseCategoryQueryRepository(ExerciseContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<ExerciseCategory> GetByUserId(int userId) {
            List<ExerciseCategoryEntity> entities = _context.ExerciseCategories!.Where(entity => entity.User!.Id == userId).ToList();

            return entities.Select(entity =>_mapper.Map<ExerciseCategory>(entity)).ToList();
        }
    }
}