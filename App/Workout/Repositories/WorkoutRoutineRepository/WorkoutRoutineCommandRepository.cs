using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.WorkoutRoutineRepository
{
    public class WorkoutRoutineCommandRepository : IWorkoutRoutineCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WorkoutRoutineCommandRepository(
            ExerciseContext context,
            ILogger<string> logger,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        private int GetUserId() =>
            int.Parse(
                _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

        public int Create()
        {
            WorkoutRoutineEntity entity = new() { User = _context.User!.Find(GetUserId()) };

            _context.WorkoutRoutine!.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public int CreateWithInput(WorkoutRoutine workoutRoutine)
        {
            WorkoutRoutineEntity entity = _mapper.Map<WorkoutRoutineEntity>(workoutRoutine);

            _context.WorkoutRoutine!.Add(entity);
            if (entity.WorkoutRoutineExercises!.Count != 0)
            {
                _context.WorkoutRoutineExercise!.AddRange(entity.WorkoutRoutineExercises);
            }
            _context.SaveChanges();

            return entity.Id;
        }

        public WorkoutRoutine CopyRoutine(int routineId)
        {
            WorkoutRoutineEntity entity = _context.WorkoutRoutine!
                .Include("WorkoutRoutineExercises.Exercise")
                .Where(o => o.Id == routineId)
                .Single();

            WorkoutRoutineEntity newEntity =
                new()
                {
                    Name = entity.Name,
                    Targets = entity.Targets,
                    Notes = entity.Notes,
                    User = _context.User.Find(GetUserId()),
                };

            List<WorkoutRoutineExerciseEntity> exerciseEntities =
                new List<WorkoutRoutineExerciseEntity>();

            _context.WorkoutRoutine!.Add(newEntity);
            _context.SaveChanges();

            if (entity.WorkoutRoutineExercises != null && entity.WorkoutRoutineExercises.Count != 0)
            {
                foreach (var item in entity.WorkoutRoutineExercises)
                {
                    WorkoutRoutineExerciseEntity exerciseEntity =
                        new()
                        {
                            Exercise = item.Exercise,
                            Notes = item.Notes,
                            NumberOfSets = item.NumberOfSets,
                            RowNumber = item.RowNumber,
                            WorkoutRoutineEntity = newEntity,
                            WorkoutRoutineEntityId = newEntity.Id,
                            User = item.User,
                        };
                    
                    exerciseEntities.Add(exerciseEntity);
                }
            }

            _context.WorkoutRoutineExercise!.AddRange(exerciseEntities);
            _context.SaveChanges();

            newEntity.WorkoutRoutineExercises = exerciseEntities;

            return _mapper.Map<WorkoutRoutine>(newEntity);
        }

        public void Update(WorkoutRoutine input)
        {
            WorkoutRoutineEntity entity = _context.WorkoutRoutine!.Find(input.Id);

            entity.Name = input.Name;
            entity.Notes = input.Notes;

            _context.WorkoutRoutine.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int workoutRoutineId)
        {
            WorkoutRoutineEntity entity = _context.WorkoutRoutine!
                .Include("WorkoutRoutineExercises")
                .Where(o => o.Id == workoutRoutineId)
                .Single();

            _context.WorkoutRoutine!.Remove(entity);
            _context.SaveChanges();
        }
    }
}
