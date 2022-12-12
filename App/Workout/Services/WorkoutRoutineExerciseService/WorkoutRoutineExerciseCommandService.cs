using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRoutineExerciseRepository;

namespace SaveApp.App.Workout.Services.WorkoutRoutineExerciseService
{
    public class WorkoutRoutineExerciseCommandService : IWorkoutRoutineExerciseCommandService
    {
        private readonly IWorkoutRoutineExerciseCommandRepository _commandRepository;

        public WorkoutRoutineExerciseCommandService(IWorkoutRoutineExerciseCommandRepository commandRepository) {
            _commandRepository = commandRepository;
        }

        public WorkoutRoutineExercise CreateForWorkoutRoutine(AddExerciseToRoutineInput input)
        {
            return _commandRepository.CreateForWorkoutRoutine(input);
        }

        public void Delete(int workoutRoutineExerciseId)
        {
            _commandRepository.Delete(workoutRoutineExerciseId);
        }

        public void Update(WorkoutRoutineExercise input)
        {
            _commandRepository.Update(input);
        }

        public void UpdateExercisesInRoutine(List<WorkoutRoutineExercise> input)
        {
            _commandRepository.UpdateExercisesInRoutine(input);
        }
    }
}