using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Controllers;

[ApiController]
[Route("api/workout/{userId}")]
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
    public int CreateWorkout(int userId)
    {
        return _workoutCommandService.Create(userId);
    }

    [HttpGet]
    public List<WorkoutDetails> GetWorkouts(int userId)
    {
        return _workoutQueryService.GetAllByUserId(userId);
    }

    [HttpGet("{workoutId}")]
    public WorkoutDetails GetWorkoutById(int userId, int workoutId)
    {
        return _workoutQueryService.GetByWorkoutId(userId, workoutId);
    }

    [HttpPut("update")]
    public void UpdateWorkout(int userId, WorkoutDetailsUpdateInput workoutDetails)
    {
        _workoutCommandService.Update(userId, workoutDetails);
    }

    [HttpPut]
    public WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise)
    {
        return _workoutCommandService.AddExerciseToWorkout(userId, exercise);
    }

    [HttpDelete("{workoutExerciseId}")]
    public void DeleteExerciseFromWorkout(int userId, int workoutExerciseId)
    {
        _workoutCommandService.DeleteWorkoutExercise(userId, workoutExerciseId);
    }

    [HttpDelete("workout/{workoutId}")]
    public void DeleteWorkout(int userId, int workoutId)
    {
        _workoutCommandService.DeleteWorkout(userId, workoutId);
    }

    [HttpPost("repeat/{workoutId}")]
    public int RepeatWorkout(int userId, int workoutId) {
        return _workoutCommandService.RepeatWorkout(userId, workoutId);
    }
}
