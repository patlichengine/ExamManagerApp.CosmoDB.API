using ExamManagerApp.CosmoDB.API.Models;
using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagerApp.CosmoDB.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UsersController(IUserRepository userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDocument>> GetUser(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserDocument>> CreateUser(UserDocument user)
        {
            // Set any additional properties if required

            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { userId = createdUser.Id }, createdUser);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDocument>> UpdateUser(string userId, UserDocument user)
        {
            var existingUser = await _userService.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            var updatedUser = await _userService.UpdateUserAsync(user);
            return Ok(updatedUser);
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var existingUser = await _userService.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }

    }
}
