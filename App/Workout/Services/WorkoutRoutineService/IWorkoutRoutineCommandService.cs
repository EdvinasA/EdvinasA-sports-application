using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutRoutineService
{
    public interface IWorkoutRoutineCommandService
    {
         int Create();
         int CreateWithInput(int workoutId);
         int CreateWorkoutFromRoutine(int routineId);
         void Update(WorkoutRoutine input);
         void Delete(int workoutRoutineId);
    }
}