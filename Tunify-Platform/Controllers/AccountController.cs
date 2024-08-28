using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccount userService;

        public AccountController(IAccount context)
        {
            userService = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdUserDto)
        {
            var user = await userService.Register(registerdUserDto, this.ModelState);


            if (ModelState.IsValid)
            {
                return user;
            }


            if (user == null)
            {
                return Unauthorized();
            }

            return BadRequest();
        }


        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userService.Login(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Ok("Logout successful"); ;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDto>> Profile()
        {
            return await userService.userProfile(User);
        }
    }
}
