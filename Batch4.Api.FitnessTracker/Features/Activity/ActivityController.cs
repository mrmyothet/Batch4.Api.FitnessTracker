using Batch4.FitnessTracker.Models.Models.Activity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.FitnessTracker.Features.Activity;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly BL_Activity _BL_Activity;

    public ActivityController(BL_Activity bl_Activity)
    {
        _BL_Activity = bl_Activity;
    }

    [HttpPost]
    public IActionResult CreateActivity(ActivityRequestModel request)
    {
        return Ok();
    }
}
