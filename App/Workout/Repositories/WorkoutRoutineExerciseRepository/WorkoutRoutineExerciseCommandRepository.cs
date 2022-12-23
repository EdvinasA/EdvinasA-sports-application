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

        public WorkoutRoutineExercise CreateForWorkoutRoutine(AddExerciseToRoutineInput input)
        {
            WorkoutRoutineExerciseEntity entity =
                new()
                {
                    Exercise = _context.Exercise!.Find(input.ExerciseId),
                    Notes = string.Empty,
                    RowNumber = input.RowNumber,
                    NumberOfSets = input.NumberOfSets,
                    User = _context.User!.Find(GetUserId()),
                    WorkoutRoutineEntity = _context.WorkoutRoutine!.Find(input.RoutineId)
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

        public void UpdateExercisesInRoutine(List<WorkoutRoutineExercise> input)
        {
            List<int> Ids = input.Select(o => o.Id).ToList();
            List<WorkoutRoutineExerciseEntity> entities = _context.WorkoutRoutineExercise!
                .Where(o => Ids.Contains(o.Id))
                .ToList();
            List<WorkoutRoutineExerciseEntity> updatedEntities = new List<WorkoutRoutineExerciseEntity>();

            entities.ForEach(
                o =>
                    input.ForEach(e =>
                    {
                        if (o.Id == e.Id && o.RowNumber != e.RowNumber)
                        {
                            o.RowNumber = e.RowNumber;
                            updatedEntities.Add(o);
                        }
                        ;
                    })
            );

            if (updatedEntities.Count == 0)
            {
                return;
            }


            _context.WorkoutRoutineExercise.UpdateRange(updatedEntities);
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
