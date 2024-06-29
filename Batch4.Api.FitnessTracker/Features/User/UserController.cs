using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.FitnessTracker.Features.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BL_User _bl_user;

        public UserController(BL_User bl_user)
        {
            _bl_user = bl_user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterModel requestModel)
        {
            try
            {
                var response = await _bl_user.RegisterAsync(requestModel);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
