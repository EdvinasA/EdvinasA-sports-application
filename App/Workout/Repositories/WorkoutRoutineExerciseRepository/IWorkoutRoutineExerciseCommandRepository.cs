using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRoutineExerciseRepository
{
    public interface IWorkoutRoutineExerciseCommandRepository
    {
        WorkoutRoutineExercise CreateForWorkoutRoutine(int ExerciseId);
        void Update(WorkoutRoutineExercise input);
        void Delete(int workoutRoutineExerciseId);
    }
}