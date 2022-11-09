using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;

namespace sports_application.App.Workout.Repositories.ExerciseSetRepository
{
    public class ExerciseSetCommandRepository : IExerciseSetCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public ExerciseSetCommandRepository(ExerciseContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(WorkoutDetailsCreateInput input) {
            
        }
    }
}