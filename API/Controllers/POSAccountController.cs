using API.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class POSAccountController(SignInManager<AppUser> signInManager) : BaseApiController
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await signInManager.UserManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized("Invalid email or password");

            var passwordResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!passwordResult.Succeeded) return Unauthorized("Invalid email or password");

            var roles = await signInManager.UserManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            if (role is not ("Admin" or "Seller"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Only admin and seller can login to POS");
            }

            await signInManager.SignInAsync(user, false);

            return Ok(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = role,
                ProfileUrl = user.ProfileUrl
            });
        }

        [Authorize(Roles = "Admin,Seller")]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
