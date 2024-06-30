using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.FitnessTracker.Features.ActivityType;

[Route("api/[controller]")]
[ApiController]
public class ActivityTypeContorller : ControllerBase
{
    private readonly BL_ActivityType _BL_Activity;

    public ActivityTypeContorller(BL_ActivityType BL_Activity)
    {
        _BL_Activity = BL_Activity;
    }

    [HttpGet]
    public IActionResult GetActivityTypeList()
    {
        var response = _BL_Activity.GetActivityTypeList();
        if (!response.MessageResponse.IsSuccess)
            return BadRequest(response.MessageResponse.Message);

        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateActivityType(string activityTypeName)
    {
        var response = _BL_Activity.CreateActivityType(activityTypeName);
        if (!response.MessageResponse.IsSuccess)
        {
            return BadRequest(response.MessageResponse.Message);
        }

        return Ok(response);
    }
}
