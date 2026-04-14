using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    public class AccountController(SignInManager<AppUser> signInManager, IMapper mapper) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult> register(RegisterDto registerDto)
        {
            var user = mapper.Map<RegisterDto, AppUser>(registerDto);
            var Createresult = await signInManager.UserManager.CreateAsync(user, registerDto.Password);
            var AddRoleResult = await signInManager.UserManager.AddToRoleAsync(user, "Customer");

            if (!Createresult.Succeeded)
            {
                foreach (var error in Createresult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }
            if (!AddRoleResult.Succeeded)
            {
                foreach (var error in AddRoleResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }
            return Ok();

        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
        [Authorize]
        [HttpGet("user-info")]
        public async Task<ActionResult> GetUserInfo()
        {
            if (User.Identity?.IsAuthenticated == false) return NoContent();

            var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);
            var userDto = mapper.Map<AppUser, UserDto>(user);
            userDto.Role = User.FindFirstValue(ClaimTypes.Role);
            return Ok(
                 userDto
            );
        }
        [HttpGet("is-authenticated")]
        public ActionResult IsAuthenticated()
        {
            return Ok(new { IsAuthenticated = User.Identity?.IsAuthenticated ?? false });
        }
        [Authorize]
        [HttpPost("address")]
        public async Task<ActionResult> AddAddress(AddressDto addressDto)
        {
            var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);
            var address = mapper.Map<AddressDto, Address>(addressDto);
            if (user.Addresses.Count <= 0)
            {
                addressDto.IsDefault = true;
                user.Addresses.Add(address);
            }
            else
            {
                if (addressDto.IsDefault)
                {
                    foreach (var adr in user.Addresses)
                    {
                        adr.IsDefault = false;
                    }
                }
                user.Addresses.Add(address);
            }

            var result = await signInManager.UserManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest();
            return Ok(mapper.Map<AppUser, UserDto>(user));
        }
        [Authorize]
        [HttpPut("address/{id}")]
        public async Task<ActionResult> UpdateAddress(Guid id, AddressDto addressDto)
        {
            var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);
            var adr = user.Addresses.FirstOrDefault(x => x.Id == id);
            if (adr == null) return NotFound();
            adr = mapper.Map(addressDto, adr);
            adr.Id = id;
            if (addressDto.IsDefault)
            {
                foreach (var a in user.Addresses)
                {
                    if (a.Id != id) a.IsDefault = false;
                }
            }
            var result = await signInManager.UserManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest();
            return Ok(mapper.Map<AppUser, UserDto>(user));
        }
        [Authorize]
        [HttpDelete("address/{id}")]
        public async Task<ActionResult> DeleteAddress(Guid id)
        {
            var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);
            var adr = user.Addresses.FirstOrDefault(x => x.Id == id);
            if (adr == null) return NotFound();
            if(adr.IsDefault)
            {
               return BadRequest("You cannot delete default address");
            }
            user.Addresses.Remove(adr);
            var result = await signInManager.UserManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest();
            return Ok(mapper.Map<AppUser, UserDto>(user));
        }
    }
}
