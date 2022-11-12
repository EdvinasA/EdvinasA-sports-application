using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace sports_application.App.Workout.Repositories.WorkoutRepository
{
    public class WorkoutQueryRepository : IWorkoutQueryRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public WorkoutQueryRepository(ExerciseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<WorkoutDetails> GetWorkouts(int UserId) {
            List<WorkoutEntity> entities = _context.Workout.Where(Workout => Workout.UserEntity.Id == UserId).ToList();
        // DELETE REPOSITORY AND COPY PASTE PROGRAM.cs AND this file
            List<WorkoutDetails> convertedValues = entities.Select(entity => _mapper.Map<WorkoutDetails>(entity)).ToList();
            convertedValues.ForEach(entity => entity.Exercises = _context.WorkoutExercise.Where(exerciseInfo => exerciseInfo.Workout.Id == 4).ToList());
            return convertedValues;
        }
    }
}