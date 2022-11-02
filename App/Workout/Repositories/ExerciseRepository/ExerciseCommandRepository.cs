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

        public ExerciseCommandRepository(ExerciseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(Exercise input) {

            var exerciseEntity = new ExerciseEntity();
            exerciseEntity.Name = input.Name;
            exerciseEntity.User = _context.User.Find(input.User.Id);
            _context.Exercise.Add(exerciseEntity);
            _context.SaveChanges();

            var ListOfExerciseSets = input.ExerciseSets
            .Select(set => new ExerciseSetEntity() 
                { Weigth = set.Weigth,
                  Reps = set.Reps,
                  Notes = set.Notes,
                  ExerciseType = set.ExerciseType,
                  UserEntity = _context.User.Find(input.User.Id),
                  ExerciseEntity = exerciseEntity })
            .ToList();
            _context.ExerciseSet.AddRange(ListOfExerciseSets);
            _context.SaveChanges();

            // _context.User.Add(UserEntity);
            // _context.ExerciseSetEntity.AddRange(ListOfExerciseSets);
            // _context.SaveChanges();
            

            // Console.WriteLine(ListOfExerciseSets.Count);
        }
    }
}