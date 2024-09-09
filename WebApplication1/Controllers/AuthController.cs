using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager1;
        private readonly IConfiguration configuration1;

        public AuthController(UserManager<IdentityUser> userManager1,  IConfiguration configuration1)
        {
            this.userManager1 = userManager1;
            this.configuration1 = configuration1;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
            };
            var identityResult = await userManager1.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {

                //add role to user (Reader)
                identityResult = await userManager1.AddToRoleAsync(user, "Reader");

                if (identityResult.Succeeded)
                {


                    return Ok();

                }

                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                    }



                }



            }


            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }



            }



            return ValidationProblem(ModelState);









        }


        [HttpGet("GetAllUsers")]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userManager1.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetUsernameByIdAsync")]
        public async Task<string> GetUsernameByIdAsync(string userId)
        {
            // Fetch the user by ID using the UserManager service
            var user = await userManager1.FindByIdAsync(userId);
            return user.UserName; // Return the username or null if user not found
        }

    }
}
