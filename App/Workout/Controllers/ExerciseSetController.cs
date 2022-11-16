using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.ExerciseSetService;

namespace SaveApp.App.Workout.Controllers;
[ApiController]
[Route("api/exercise-set/{userId}")]
public class ExerciseSetController
{
    private readonly IExerciseSetCommandService _commandService;

    public ExerciseSetController(IExerciseSetCommandService commandService) 
    {
        _commandService = commandService;
    }

    [HttpPost]
    public ExerciseSet Create(int userId, ExerciseSetCreateInput input) {
        return _commandService.Create(input);
    }

    [HttpDelete("{exerciseSetId}")]
    public void Delete(int userId, int exerciseSetId) {
        _commandService.Delete(exerciseSetId);
    }
}