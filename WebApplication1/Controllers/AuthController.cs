using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories.Implementation;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager1;
        private readonly IConfiguration configuration1;
        private readonly ITokenRepository tokenrepository;

        public ILogger<AuthController> Logger { get; }

        public AuthController(UserManager<ApplicationUser> userManager1,  IConfiguration configuration1,ITokenRepository  tokenrepository, ILogger<AuthController> logger)
        {
            this.userManager1 = userManager1;
            this.configuration1 = configuration1;
            this.tokenrepository = tokenrepository;
            Logger = logger;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var user = new ApplicationUser
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


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  LoginRequestDto  request)
        {
          var identityUser = await userManager1.FindByEmailAsync(request.Email);
         
            if (identityUser is not null)
            {

                var checkpasswordresult = await userManager1.CheckPasswordAsync(identityUser, request.Password);
                Logger.LogInformation($"Password check result: {checkpasswordresult}");

                if (checkpasswordresult)
                {


                    



                    var roles = await userManager1.GetRolesAsync(identityUser);
                  var jwttoken=  tokenrepository.CreateJwttoken(identityUser, roles.ToList());
                    var response = new LoginResponseDto
                    {
                        Email = request.Email,
                        Roles = roles.ToList(),
                        Token= jwttoken



                    };

                    return Ok(response);
                }

            }
            ModelState.AddModelError("","Email or Password is incorrect");

            return ValidationProblem(ModelState);

        }















    }
}
