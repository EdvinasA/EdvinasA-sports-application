using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;
using SaveApp.App.Workout.Repositories.ExerciseRepository;
using SaveApp.App.Workout.Services;

namespace SaveApp.App.Workout.Repositories.ExerciseCategoryRepository
{
    public class ExerciseCategoryCommandRepository : IExerciseCategoryCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly IExerciseCommandRepository _exerciseCommandRepository;

        public ExerciseCategoryCommandRepository(
            ExerciseContext context,
            IMapper mapper,
            IExerciseCommandRepository exerciseCommandRepository
        )
        {
            _context = context;
            _mapper = mapper;
            _exerciseCommandRepository = exerciseCommandRepository;
        }

        public ExerciseCategory Create(int userId, ExerciseCategory input)
        {
            ExerciseCategoryEntity entity = _mapper.Map<ExerciseCategoryEntity>(input);
            entity.User = _context.User!.Find(userId);

            _context.ExerciseCategories!.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<ExerciseCategory>(entity);
        }

        public void Update(int userId, ExerciseCategory input)
        {
            ExerciseCategoryEntity entity = _mapper.Map<ExerciseCategoryEntity>(input);
            entity.User = _context.User!.Find(userId);

            _context.ExerciseCategories!.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int userId, int categoryId)
        {
            ExerciseCategoryEntity entity = _context.ExerciseCategories!
                .Include("Exercise")
                .FirstOrDefault(o => o.Id == categoryId);

            foreach (var item in entity.Exercise)
            {
                _exerciseCommandRepository.Delete(userId, item.Id);
            }

            _context.ExerciseCategories.Remove(entity);
            _context.SaveChanges();
        }
    }
}
