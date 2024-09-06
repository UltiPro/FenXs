using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FenXs.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string? requestId { get; set; }
    public bool showRequestId => !string.IsNullOrEmpty(requestId);
    private readonly ILogger<ErrorModel> logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        this.logger = logger;
    }

    public void OnGet()
    {
        requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}