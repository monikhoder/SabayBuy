using Core.Dtos;

namespace Core.Interface;

public interface IAdminDashboardService
{
    Task<AdminDashboardDto> GetDashboardAsync();
}
