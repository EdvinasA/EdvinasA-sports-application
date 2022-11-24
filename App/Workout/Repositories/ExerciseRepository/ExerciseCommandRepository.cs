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

        public void Create(int userId, Exercise input)
        {

            var exerciseEntity = new ExerciseEntity();
            exerciseEntity.Name = input.Name;
            exerciseEntity.User = _context.User!.Find(userId);
            _context.Exercise!.Add(exerciseEntity);
            _context.SaveChanges();
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