using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseCategoryRepository
{
    public class ExerciseCategoryCommandRepository : IExerciseCategoryCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public ExerciseCategoryCommandRepository(ExerciseContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public ExerciseCategory Create(int userId, ExerciseCategory input) {
            ExerciseCategoryEntity entity = _mapper.Map<ExerciseCategoryEntity>(input);
            entity.User = _context.User!.Find(userId);

            _context.ExerciseCategories!.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<ExerciseCategory>(entity);
        }

        public void Update(int userId, ExerciseCategory input) {
            ExerciseCategoryEntity entity = _mapper.Map<ExerciseCategoryEntity>(input);
            entity.User = _context.User!.Find(userId);

            _context.ExerciseCategories!.Update(entity);
            _context.SaveChanges();
        }
    }
}