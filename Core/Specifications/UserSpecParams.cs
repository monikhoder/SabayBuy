using System;

namespace Core.Specifications;

public class UserSpecParams
{
    private const int MaxPageSize = 100;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public string? Sort { get; set; }
    public string? Search { get; set; }
    private List<string> _roles = [];
    public List<string> Roles
    {
        get => _roles;
        set
        {
            _roles = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }
}
