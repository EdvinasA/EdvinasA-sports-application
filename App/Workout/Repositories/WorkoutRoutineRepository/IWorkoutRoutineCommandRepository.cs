using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRoutineRepository
{
    public interface IWorkoutRoutineCommandRepository
    {
         int Create();
         int CreateWithInput(WorkoutRoutine workoutRoutine);
         void Update(WorkoutRoutine input);
         void Delete(int workoutRoutineId);
    }
}