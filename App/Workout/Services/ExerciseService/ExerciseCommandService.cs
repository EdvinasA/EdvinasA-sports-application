using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Services
{
    public class ExerciseCommandService : IExerciseCommandService
    {
        private readonly IMapper _mapper;

        public ExerciseCommandService(IMapper mapper) {
            _mapper = mapper;
        }

        public void CreateExercise(Exercise exercise) 
        {
            var result = _mapper.Map<ExerciseSetEntity>(exercise.ExerciseSets);

            Console.WriteLine(exercise.Name);
        }

        public void UpdateExercise(Exercise exercise) 
        {

        }
    }
}