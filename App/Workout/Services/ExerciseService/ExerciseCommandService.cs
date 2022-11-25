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

        public Exercise CreateExercise(int userId, ExerciseCreateInput exercise) 
        {
            return _exerciseCommandRepository.Create(userId, exercise);
        }

        public void UpdateExercise(int userId, Exercise exercise) 
        {

        }
        public void Delete(int userId, int exerciseId) {
            _exerciseCommandRepository.Delete(userId, exerciseId);
        }
    }
}