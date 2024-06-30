using Batch4.FitnessTracker.Models.Models.Activity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.FitnessTracker.Features.Activity;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly BL_Activity _bl_Activity;

    public ActivityController(BL_Activity bl_Activity)
    {
        _bl_Activity = bl_Activity;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivityAsync(ActivityRequestModel request)
    {
        ActivityResponseModel response = await _bl_Activity.CreateActivityAsync(request);

        if (!response.MessageResponse.IsSuccess)
            return BadRequest(response.MessageResponse.Message);

        return Ok(response);
    }

    [HttpGet("{userId}")]
    public IActionResult GetActivitiesByUserId(int userId)
    {
        var lst = _bl_Activity.GetActivitiesByUserId(userId);
        if (lst.Count == 0)
            return NotFound("No activity found.");

        return Ok(lst);
    }
}
