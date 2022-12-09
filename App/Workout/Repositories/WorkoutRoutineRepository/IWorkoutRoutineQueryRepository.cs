using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRoutineRepository
{
    public interface IWorkoutRoutineQueryRepository
    {
         List<WorkoutRoutine> GetAll();
         WorkoutRoutine GetById(int workoutRoutineId);
    }
}