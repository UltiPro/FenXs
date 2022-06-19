using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels.VisitorPageModel;

public class VisitorPageModel : PageModel
{
    public IActionResult OnGet()
    {
        if (!HttpContext.Session.IsAvailable) return RedirectToPage("/Main");
        return Page();
    }
}