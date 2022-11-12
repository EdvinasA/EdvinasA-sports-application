using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
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

        public ExerciseSet Create(ExerciseSetCreateInput input) {
            ExerciseSetEntity entity = _mapper.Map<ExerciseSetEntity>(input);
            entity.ExerciseEntity = _context.Exercise?.Find(input.ExerciseId);
            entity.WorkoutExerciseEntity = _context.WorkoutExercise?.Find(input.WorkoutExerciseId);
            entity.UserEntity = _context.User?.Find(input.UserId);

            _context.ExerciseSet?.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<ExerciseSet>(entity);
        }
    }
}