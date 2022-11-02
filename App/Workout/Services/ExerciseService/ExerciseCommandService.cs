using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;
using SaveApp.App.Workout.Repositories.ExerciseRepository;

namespace SaveApp.App.Workout.Services
{
    public class ExerciseCommandService : IExerciseCommandService
    {
        private readonly IMapper _mapper;
        private readonly IExerciseCommandRepository _exerciseCommandRepository;

        public ExerciseCommandService(IMapper mapper, IExerciseCommandRepository exerciseCommandRepository) {
            _mapper = mapper;
            _exerciseCommandRepository = exerciseCommandRepository;
        }

        public void CreateExercise(Exercise exercise) 
        {
            _exerciseCommandRepository.Create(exercise);

            Console.WriteLine(exercise.Name);
        }

        public void UpdateExercise(Exercise exercise) 
        {

        }

        public List<ExerciseEntity> GetAllExercises() {
            return _exerciseCommandRepository.GetExercises();
        }
    }
}