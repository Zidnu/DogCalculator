using API.CustomExceptions;
using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders.Physical;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpPost("register")]
    
        public async Task<ActionResult<RegisterRes>> Register(RegisterReq requestData)
        {
            try
            {
                var user = await _userService.Register(requestData.UserName, requestData.Password);
                return new RegisterRes
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Role = user.Role
                };
            }

            catch (UserRegistrationsException e)
            {
                return Conflict(new { title = "Error creating user", detail = e.Message});
            }

            catch (Exception)
            {
                return Problem(
                    title: "Error creating user",
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }
    }
}