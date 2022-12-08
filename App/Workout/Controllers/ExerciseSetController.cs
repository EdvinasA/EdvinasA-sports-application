using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.ExerciseSetService;

namespace SaveApp.App.Workout.Controllers;

[Authorize]
[ApiController]
[Route("api/exercise-set")]
public class ExerciseSetController
{
    private readonly IExerciseSetCommandService _commandService;

    public ExerciseSetController(IExerciseSetCommandService commandService)
    {
        _commandService = commandService;
    }

    [HttpPost]
    public ExerciseSet Create(ExerciseSetCreateInput input)
    {
        return _commandService.Create(input);
    }

    [HttpDelete("{exerciseSetId}")]
    public void Delete(int exerciseSetId)
    {
        _commandService.Delete(exerciseSetId);
    }

    [HttpPut]
    public void UpdateSet(ExerciseSet exerciseSet)
    {
        _commandService.Update(exerciseSet);
    }
}
