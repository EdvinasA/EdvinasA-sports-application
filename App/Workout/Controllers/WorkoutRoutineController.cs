using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.WorkoutRoutineService;

namespace SaveApp.App.Workout.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/workout-routine")]
    public class WorkoutRoutineController
    {
        private readonly IWorkoutRoutineQueryService _queryService;
        private readonly IWorkoutRoutineCommandService _commandService;

        public WorkoutRoutineController(IWorkoutRoutineQueryService queryService, IWorkoutRoutineCommandService commandService) {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpPost]
        public int Create() {
            return _commandService.Create();
        }

        [HttpPost("{workoutId}")]
        public int CreateWithInput(int workoutId) {
            return _commandService.CreateWithInput(workoutId);
        }

        [HttpGet]
        public List<WorkoutRoutine> GetAll() {
            return _queryService.GetAll();
        }

        [HttpGet("{workoutRoutineId}")]
        public WorkoutRoutine GetById(int workoutRoutineId) {
            return _queryService.GetById(workoutRoutineId);
        }      

        [HttpDelete("{workoutRoutineId}")]
        public void DeleteById(int workoutRoutineId) {
            _commandService.Delete(workoutRoutineId);
        }

        [HttpPut]
        public void Update(WorkoutRoutine workoutRoutine) {
            _commandService.Update(workoutRoutine);
        }
    }
}