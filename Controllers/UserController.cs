using ContactList.Domain;
using ContactList.Persistance.Repositories;
using ContactList.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ContactController> _logger;
        private readonly IAuthManager _authManager;

        public UserController(
            ILogger<ContactController> logger,
            UserManager<User> userManager,
            IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister userToRegister)
        {

            _logger.LogInformation($"Register attempt for {userToRegister.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = new User();
                user.FirstName = userToRegister.FirstName;
                user.LastName = userToRegister.LastName;
                user.Email = userToRegister.Email;
                user.UserName = userToRegister.Email;
                var result = await _userManager.CreateAsync(user, userToRegister.Password);

                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);    
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRolesAsync(user, userToRegister.Roles);

                return Accepted();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userToLogin)
        {
            _logger.LogInformation($"Login attempt for {userToLogin.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                if (!await _authManager.ValidateUser(userToLogin))
                {
                    return Unauthorized();
                }
                return Accepted(new {Token = await _authManager.GenerateToken()});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
        }
    }
}