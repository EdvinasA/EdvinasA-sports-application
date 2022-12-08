using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Controllers;

[Authorize]
[ApiController]
[Route("api/workout")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutCommandService _workoutCommandService;
    private readonly IWorkoutQueryService _workoutQueryService;
    private readonly ILogger _logger;

    public WorkoutController(
        IWorkoutCommandService workoutCommandService,
        IWorkoutQueryService workoutQueryService,
        ILogger<string> logger
    )
    {
        _workoutCommandService = workoutCommandService;
        _workoutQueryService = workoutQueryService;
        _logger = logger;
    }

    [HttpPost]
    public int CreateWorkout()
    {
        return _workoutCommandService.Create();
    }

    [HttpGet]
    public List<WorkoutDetails> GetWorkouts()
    {
        return _workoutQueryService.GetAllByUserId();
    }

    [HttpGet("{workoutId}")]
    public WorkoutDetails GetWorkoutById(int workoutId)
    {
        return _workoutQueryService.GetByWorkoutId(workoutId);
    }

    [HttpPut("update")]
    public void UpdateWorkout(WorkoutDetailsUpdateInput workoutDetails)
    {
        _workoutCommandService.Update(workoutDetails);
    }

    [HttpPut]
    public WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise)
    {
        return _workoutCommandService.AddExerciseToWorkout(exercise);
    }

    [HttpDelete("{workoutExerciseId}")]
    public void DeleteExerciseFromWorkout(int workoutExerciseId)
    {
        _workoutCommandService.DeleteWorkoutExercise(workoutExerciseId);
    }

    [HttpDelete("workout/{workoutId}")]
    public void DeleteWorkout(int workoutId)
    {
        _workoutCommandService.DeleteWorkout(workoutId);
    }

    [HttpPost("repeat/{workoutId}")]
    public int RepeatWorkout(int workoutId) {
        return _workoutCommandService.RepeatWorkout(workoutId);
    }
}
