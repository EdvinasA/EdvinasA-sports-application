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

        public ExerciseCommandService(
            IMapper mapper,
            IExerciseCommandRepository exerciseCommandRepository
        )
        {
            _mapper = mapper;
            _exerciseCommandRepository = exerciseCommandRepository;
        }

        public Exercise CreateExercise(ExerciseCreateInput exercise)
        {
            return _exerciseCommandRepository.Create(exercise);
        }

        public void UpdateExercise(Exercise exercise)
        {
            _exerciseCommandRepository.Update(exercise);
        }

        public void Delete(int exerciseId)
        {
            _exerciseCommandRepository.Delete(exerciseId);
        }
    }
}
