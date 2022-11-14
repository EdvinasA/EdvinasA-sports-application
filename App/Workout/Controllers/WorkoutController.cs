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
    
    public WorkoutController(IWorkoutCommandService workoutCommandService, IWorkoutQueryService workoutQueryService) {
        _workoutCommandService = workoutCommandService;
        _workoutQueryService = workoutQueryService;
    }

    [HttpPost]
    public void CreateWorkout(int userId) {
        _workoutCommandService.Create(userId);
    }

    [HttpGet]
    public List<WorkoutDetails> GetWorkouts(int userId) {
        return _workoutQueryService.GetAllByUserId(userId);
    }

    [HttpGet("{workoutId}")]
    public WorkoutDetails GetWorkoutById(int userId, int workoutId) {
        return _workoutQueryService.GetByWorkoutId(userId, workoutId);
    }
}