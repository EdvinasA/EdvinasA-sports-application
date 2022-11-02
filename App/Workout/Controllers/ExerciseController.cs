using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;
using SaveApp.App.Workout.Services;
using sports_application.App.Workout.Services.WorkoutService;
using System.Web.Http.Cors;

namespace SaveApp.App.Workout.Controllers;


[ApiController]
[Route("api/exercise/{userId}")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseCommandService _commandService;
    private readonly IWorkoutCommandService _workoutCommandService;

    public ExerciseController(IExerciseCommandService commandService, IWorkoutCommandService workoutCommandService) {
        _commandService = commandService;
        _workoutCommandService = workoutCommandService;
    }

    [HttpPost("create-exercise")]
    public void Create(int userId, Exercise exercise) {
        _commandService.CreateExercise(userId, exercise);
    }

    [HttpPost("create-workout")]
    public void Create(int userId, WorkoutDetails workoutDetails) {
        _workoutCommandService.Create(userId, workoutDetails);
    }

    [HttpGet]
    public List<ExerciseEntity> GetExercises(int userId) {
        return _commandService.GetAllExercises(userId);
    }

    [HttpGet("set")]
    public List<ExerciseSet> GetExerciseSets(int userId) {
        return null;
    }

    [HttpGet("workout")]
    public List<ExerciseSet> GetWorkouts(int userId) {
        return null;
    }

    [HttpGet("workout/{workoutId}")]
    public List<ExerciseSet> GetWorkoutById(int userId, int workoutId) {
        return null;
    }
}