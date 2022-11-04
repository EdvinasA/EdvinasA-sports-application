using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using sports_application.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Controllers;

[ApiController]
[Route("api/workout/{userId}")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutCommandService _workoutCommandService;
    
    public WorkoutController(IWorkoutCommandService workoutCommandService) {
        _workoutCommandService = workoutCommandService;
    }

    [HttpPost("create")]
    public void CreateWorkout(int userId, WorkoutDetails workoutDetails) {
        _workoutCommandService.Create(userId, workoutDetails);
    }

    [HttpGet]
    public List<ExerciseSet> GetWorkouts(int userId) {
        return null;
    }

    [HttpGet("{workoutId}")]
    public List<ExerciseSet> GetWorkoutById(int userId, int workoutId) {
        return null;
    }
}