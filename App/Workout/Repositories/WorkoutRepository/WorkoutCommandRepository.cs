using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace sports_application.App.Workout.Repositories.WorkoutRepository
{
    public class WorkoutCommandRepository : IWorkoutCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public WorkoutCommandRepository(ExerciseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(int userId, WorkoutDetails workoutDetails) {
            WorkoutEntity workoutEntity = _mapper.Map<WorkoutEntity>(workoutDetails);
            workoutEntity.UserEntity = _context.User.First(user => user.Id == userId);

            _context.Workout.Add(workoutEntity);
            _context.SaveChanges();
        }
    }
}