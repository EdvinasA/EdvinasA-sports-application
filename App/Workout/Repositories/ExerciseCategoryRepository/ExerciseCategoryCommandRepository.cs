using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseCategoryCommandRepository(
            ExerciseContext context,
            IMapper mapper,
            IExerciseCommandRepository exerciseCommandRepository,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _mapper = mapper;
            _exerciseCommandRepository = exerciseCommandRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public ExerciseCategory Create(ExerciseCategory input)
        {
            ExerciseCategoryEntity entity = _mapper.Map<ExerciseCategoryEntity>(input);
            entity.User = _context.User!.Find(GetUserId());

            _context.ExerciseCategories!.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<ExerciseCategory>(entity);
        }

        public void Update(ExerciseCategory input)
        {
            ExerciseCategoryEntity entity = _mapper.Map<ExerciseCategoryEntity>(input);
            entity.User = _context.User!.Find(GetUserId());

            _context.ExerciseCategories!.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            ExerciseCategoryEntity entity = _context.ExerciseCategories!
                .Include("Exercise")
                .FirstOrDefault(o => o.Id == categoryId);

            foreach (var item in entity.Exercise)
            {
                _exerciseCommandRepository.Delete(item.Id);
            }
            

            _context.ExerciseCategories.Remove(entity);
            _context.SaveChanges();
        }
    }
}
