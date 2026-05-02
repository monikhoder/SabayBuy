using Core.Dtos;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Admin,Seller,Stock")]
public class AdminDashboardController(IAdminDashboardService dashboardService) : BaseApiController
{
    // GET: api/AdminDashboard
    [HttpGet]
    public async Task<ActionResult<AdminDashboardDto>> GetDashboard()
    {
        return Ok(await dashboardService.GetDashboardAsync());
    }
}
