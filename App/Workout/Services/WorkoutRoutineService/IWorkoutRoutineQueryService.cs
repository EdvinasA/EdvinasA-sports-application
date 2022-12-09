using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutRoutineService
{
    public interface IWorkoutRoutineQueryService
    {
        List<WorkoutRoutine> GetAll();
         WorkoutRoutine GetById(int workoutRoutineId);
    }
}