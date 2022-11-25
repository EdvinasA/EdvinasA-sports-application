using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseRepository
{
    public class ExerciseCommandRepository : IExerciseCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseCommandRepository(ExerciseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public Exercise Create(int userId, ExerciseCreateInput input)
        {

            var exerciseEntity = _mapper.Map<ExerciseEntity>(input);
            exerciseEntity.ExerciseCategory = _context.ExerciseCategories!.Find(input.ExerciseCategoryId);
            exerciseEntity.User = _context.User!.Find(userId);
            _context.Exercise!.Add(exerciseEntity);
            _context.SaveChanges();

            return _mapper.Map<Exercise>(exerciseEntity);
        }

        public void Update(int userId, Exercise input) {
            var exerciseEntity = _context.Exercise.Find(input.Id);
            exerciseEntity.Name = input.Name;
            // exerciseEntity.ExerciseBodyPart = input.ExerciseBodyPart;
            exerciseEntity.User = _context.User!.Find(userId);
            _context.Exercise!.Add(exerciseEntity);
            _context.SaveChanges();
        }
    }
}