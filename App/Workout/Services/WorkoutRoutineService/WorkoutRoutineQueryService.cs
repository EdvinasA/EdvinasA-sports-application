using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRoutineRepository;

namespace SaveApp.App.Workout.Services.WorkoutRoutineService
{
    public class WorkoutRoutineQueryService : IWorkoutRoutineQueryService
    {
        private readonly IWorkoutRoutineQueryRepository _queryRepository;

        public WorkoutRoutineQueryService(IWorkoutRoutineQueryRepository queryRepository) {
            _queryRepository = queryRepository;
        }
        public List<WorkoutRoutine> GetAll()
        {
            return _queryRepository.GetAll();
        }

        public WorkoutRoutine GetById(int workoutRoutineId)
        {
            return _queryRepository.GetById(workoutRoutineId);
        }
    }
}