using System.Threading.Tasks;
using eCommerce_Insanity.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_Insanity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = new IdentityUser
            {
                UserName = createUserDTO.UserName,
                Email = createUserDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, createUserDTO.Password);

            if (result.Succeeded)
            {
                //Future: Return a 201 Created response
                //Will want a GetUser endpoint so I can send user back to the frontend client
                return Ok(new { message = "User created successfully!" });
            }

            return BadRequest(result.Errors);
        }

        // [HttpPost("login")]
        // public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        // {
        //     var user = await _userManager.FindByEmailAsync(loginDTO.Email);

        //     if (user == null)
        //     {
        //         return Unauthorized();
        //     }

        //     var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

        //     if (result)
        //     {
        //         return Ok();
        //     }

        //     return Unauthorized();
        // }
    }
}
