using System.Security.Claims;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.WorkoutRoutineExerciseRepository
{
    public class WorkoutRoutineExerciseCommandRepository : IWorkoutRoutineExerciseCommandRepository
    {
        private readonly ExerciseContext _context;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WorkoutRoutineExerciseCommandRepository(
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

        public WorkoutRoutineExercise CreateForWorkoutRoutine(int exerciseId)
        {
            WorkoutRoutineExerciseEntity entity =
                new()
                {
                    Exercise = _context.Exercise!.Find(exerciseId),
                    Notes = string.Empty,
                    NumberOfSets = 0,
                    User = _context.User!.Find(GetUserId())
                };

            _context.WorkoutRoutineExercise!.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<WorkoutRoutineExercise>(entity);
        }

        public void Update(WorkoutRoutineExercise input)
        {
            WorkoutRoutineExerciseEntity entity = _context.WorkoutRoutineExercise!.Find(input.Id);

            entity!.Notes = input.Notes;
            entity.NumberOfSets = input.NumberOfSets;

            _context.WorkoutRoutineExercise.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int workoutRoutineExerciseId)
        {
            WorkoutRoutineExerciseEntity entity = _context.WorkoutRoutineExercise!.Find(
                workoutRoutineExerciseId
            );

            if (entity != null)
            {
                _context.WorkoutRoutineExercise.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
