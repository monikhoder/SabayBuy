using System;

namespace Core.Specifications;

public class ProductSpecParams
{
    private List<string> _brands = [];
    public List<string> Brands
    {
        get => _brands;
        set {
            _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }

    }
    private List<string> _categories = [];
    public List<string> Categories
    {
        get => _categories;
        set {
            _categories = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }

    }
    public string? Sort { get; set; }
    public string? Search { get; set; }

}
