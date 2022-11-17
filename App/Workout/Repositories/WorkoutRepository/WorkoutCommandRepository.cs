using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
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

        public void Create(int userId, WorkoutDetailsCreateInput input) {
            WorkoutEntity workoutEntity = _mapper.Map<WorkoutEntity>(input);
            workoutEntity.UserEntity = _context.User!.First(user => user.Id == userId);

            _context.Workout!.Add(workoutEntity);
            _context.SaveChanges();
        }

        public WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise) {
            WorkoutExerciseEntity entity = new WorkoutExerciseEntity();
            entity.Exercise = _context.Exercise.Find(exercise.Exercise.Id);
            entity.RowNumber = exercise.RowNumber;
            entity.User = _context.User.Find(userId);

            _context.WorkoutExercise.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<WorkoutExercise>(entity);
        }
    }
}