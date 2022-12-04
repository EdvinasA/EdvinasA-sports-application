using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public class WorkoutCommandRepository : IWorkoutCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public WorkoutCommandRepository(
            ExerciseContext context,
            IMapper mapper,
            ILogger<string> logger
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public int Create(int userId, WorkoutDetailsCreateInput input)
        {
            WorkoutEntity workoutEntity = _mapper.Map<WorkoutEntity>(input);
            workoutEntity.UserEntity = _context.User!.First(user => user.Id == userId);

            _context.Workout!.Add(workoutEntity);
            _context.SaveChanges();

            return workoutEntity.Id;
        }

        public WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise)
        {
            WorkoutExerciseEntity entity = new WorkoutExerciseEntity();
            entity.Exercise = _context.Exercise!.Find(exercise.Exercise.Id);
            entity.RowNumber = exercise.RowNumber;
            entity.User = _context.User!.Find(userId);
            entity.WorkoutEntity = _context.Workout!.Find(exercise.WorkoutId);

            _context.WorkoutExercise!.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<WorkoutExercise>(entity);
        }

        public void Update(int userId, WorkoutDetailsUpdateInput workoutDetails)
        {
            WorkoutEntity entity = _context.Workout!.Find(workoutDetails.Id);
            entity.BodyWeight = workoutDetails.BodyWeight;
            entity.Date = workoutDetails.Date;
            entity.StartTime = workoutDetails.StartTime;
            entity.EndTime = workoutDetails.EndTime;
            entity.Name = workoutDetails.Name;
            entity.Notes = workoutDetails.Notes;

            _context.Workout.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteWorkoutExercise(int userId, int workoutExerciseId)
        {
            try
            {
                WorkoutExerciseEntity entity = _context.WorkoutExercise
                    .Include("ExerciseSets")
                    .FirstOrDefault(e => e.Id == workoutExerciseId);

                _context.ExerciseSet!.RemoveRange(entity.ExerciseSets);
                _context.SaveChanges();
                _context.WorkoutExercise!.Remove(entity);
                _context.SaveChanges();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteWorkout(int userId, int workoutId)
        {
            WorkoutEntity entity = _context.Workout
                .Include("Exercises.ExerciseSets")
                .FirstOrDefault(e => e.Id == workoutId);

            if (entity.Exercises != null || entity.Exercises.Count() != 0)
            {
                foreach (var item in entity.Exercises)
                {
                    DeleteWorkoutExercise(userId, item.Id);
                }
            }

            _context.Workout.Remove(entity);
            _context.SaveChanges();
        }
    }
}
