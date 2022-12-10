using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkoutCommandRepository(
            ExerciseContext context,
            IMapper mapper,
            ILogger<string> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public int Create(WorkoutDetailsCreateInput input)
        {
            WorkoutEntity workoutEntity = _mapper.Map<WorkoutEntity>(input);
            workoutEntity.UserEntity = _context.User!.First(user => user.Id == GetUserId());

            _context.Workout!.Add(workoutEntity);
            _context.SaveChanges();

            return workoutEntity.Id;
        }

        public WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise)
        {
            WorkoutExerciseEntity entity = new WorkoutExerciseEntity();
            entity.Exercise = _context.Exercise!.Find(exercise.Exercise.Id);
            entity.RowNumber = exercise.RowNumber;
            entity.User = _context.User!.Find(GetUserId());
            entity.WorkoutEntity = _context.Workout!.Find(exercise.WorkoutId);

            _context.WorkoutExercise!.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<WorkoutExercise>(entity);
        }

        public void Update(WorkoutDetailsUpdateInput workoutDetails)
        {
            WorkoutEntity entity = _context.Workout!.Find(workoutDetails.Id);
            entity.BodyWeight = workoutDetails.BodyWeight;
            entity.Date = (DateTime)workoutDetails.Date;
            entity.StartTime = workoutDetails.StartTime;
            entity.EndTime = workoutDetails.EndTime;
            entity.Name = workoutDetails.Name;
            entity.Notes = workoutDetails.Notes;

            _context.Workout.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateExercises(List<WorkoutExercise> exercises) {
            List<WorkoutExerciseEntity> entities = exercises.Select(o => _mapper.Map<WorkoutExerciseEntity>(o)).ToList();

            _context.WorkoutExercise.UpdateRange(entities);
            _context.SaveChanges();
        }

        public void DeleteWorkoutExercise(int workoutExerciseId)
        {
            try
            {
                WorkoutExerciseEntity entity = _context.WorkoutExercise
                    .Include("ExerciseSets")
                    .FirstOrDefault(e => e.Id == workoutExerciseId);

                _context.WorkoutExercise!.Remove(entity);
                _context.SaveChanges();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteWorkout(int workoutId)
        {
            WorkoutEntity entity = _context.Workout
                .Include("Exercises.ExerciseSets")
                .FirstOrDefault(e => e.Id == workoutId);

            _context.Workout.Remove(entity);
            _context.SaveChanges();
        }
    }
}
