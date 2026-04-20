using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Infrastructure.Data;

namespace API.Controllers;

[Authorize(Roles = "Admin")]
public class UsermanageController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, StoreContext context) : BaseApiController
{
    //Get user list
    [HttpGet]
    public async Task<ActionResult<Pagination<UserDto>>> GetUsers([FromQuery] UserSpecParams specParams)
    {
        var currentUserEmail = User.GetEmail();
        var query = userManager.Users
            .Include(x => x.Addresses)
            .Where(x => x.Email != currentUserEmail)
            .AsQueryable();

        if (specParams.Roles.Count > 0)
        {
            var roleIds = await roleManager.Roles
                .Where(r => specParams.Roles.Contains(r.Name!))
                .Select(r => r.Id)
                .ToListAsync();

            query = query.Where(u => context.UserRoles
                .Where(ur => roleIds.Contains(ur.RoleId))
                .Select(ur => ur.UserId)
                .Contains(u.Id));
        }

        if (!string.IsNullOrEmpty(specParams.Search))
        {
            var search = specParams.Search.ToLower();
            query = query.Where(x => x.Email!.ToLower().Contains(search)
                || x.FirstName.ToLower().Contains(search)
                || x.LastName.ToLower().Contains(search));
        }

        return await CreateUserPagedResult(query, specParams.PageIndex, specParams.PageSize);
    }
    private async Task<ActionResult<Pagination<UserDto>>> CreateUserPagedResult(IQueryable<AppUser> query, int pageIndex, int pageSize)
    {
        var count = await query.CountAsync();

        var users = await query
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToListAsync();

        var userDtos = new List<UserDto>();
        foreach (var user in users)
        {
            var userDto = mapper.Map<AppUser, UserDto>(user);
            var roles = await userManager.GetRolesAsync(user);
            userDto.Role = roles.FirstOrDefault();
            userDtos.Add(userDto);
        }

        return Ok(new Pagination<UserDto>(pageIndex, pageSize, count, userDtos));
    }



    //Promote user role
    [HttpPost("promote")]
    public async Task<ActionResult> PromoteUser(PromoteUserDto promoteUserDto)
    {
        var roleExists = await roleManager.RoleExistsAsync(promoteUserDto.Role);
        if (!roleExists)
        {
            return BadRequest("Invalid role. Role does not exist.");
        }

        var user = await userManager.FindByIdAsync(promoteUserDto.UserId);
        if (user == null) return NotFound("User not found");

        var roles = await userManager.GetRolesAsync(user);
        var removeResult = await userManager.RemoveFromRolesAsync(user, roles);

        if (!removeResult.Succeeded) return BadRequest("Failed to remove existing roles");

        var addResult = await userManager.AddToRoleAsync(user, promoteUserDto.Role);

        if (!addResult.Succeeded) return BadRequest("Failed to add new role");

        return Ok(new { message = $"User role updated to {promoteUserDto.Role}" });
    }

}
