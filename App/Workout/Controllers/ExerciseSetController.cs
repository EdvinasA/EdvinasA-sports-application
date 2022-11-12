using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.ExerciseSetService;

namespace SaveApp.App.Workout.Controllers;
[ApiController]
[Route("api/exercise-set/{userId}")]
public class ExerciseSetController
{
    private readonly ExerciseSetCommandService _commandService;

    public ExerciseSetController(ExerciseSetCommandService commandService) 
    {
        _commandService = commandService;
    }

    [HttpPost]
    public ExerciseSet Create(ExerciseSetCreateInput input) {
        return new ExerciseSet();
    }
}