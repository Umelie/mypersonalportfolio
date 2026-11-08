using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myportfolio.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _env;

    public PortfolioData Data { get; private set; } = new();

    public IndexModel(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void OnGet()
    {
        var path = Path.Combine(_env.ContentRootPath, "Data", "portfolio.json");
        var json = System.IO.File.ReadAllText(path);

        Data = JsonSerializer.Deserialize<PortfolioData>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
    }
}