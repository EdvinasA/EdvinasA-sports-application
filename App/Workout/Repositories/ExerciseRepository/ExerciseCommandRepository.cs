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

        public ExerciseCommandRepository(ExerciseContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Exercise input) {
            var listOfExerciseSets = input.ExerciseSets
            .Select(set => _mapper.Map<ExerciseSetEntity>(set))
            .ToList();

            // var userEntity = new UserEntity();
            // userEntity.Email = "edvinasalimas98@gmail.com";
            // userEntity.FirstName = "Edvinas";
            // userEntity.LastName = "Alimas";

            // _context.User.Add(UserEntity);
            // _context.ExerciseSetEntity.AddRange(listOfExerciseSets);
            // _context.SaveChanges();

            var exerciseEntity = new ExerciseEntity();
            exerciseEntity.ExerciseSetsEntities = listOfExerciseSets;
            

            Console.WriteLine(listOfExerciseSets.Count);
            _context.Exercise.Add(exerciseEntity);
            _context.SaveChanges();
        }
    }
}