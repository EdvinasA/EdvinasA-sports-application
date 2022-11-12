using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
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
            List<WorkoutEntity> entities = _context.Workout
            .Include("Exercises.Exercise")
            .Include("Exercises.ExerciseSets")
            .Where(workout => workout.UserEntity.Id == UserId).ToList();
            
            return entities.Select(entity => _mapper.Map<WorkoutDetails>(entity)).ToList();
        }
    }
}