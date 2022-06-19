using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels.VisitorPageModel;

public class VisitorPageModel : PageModel
{
    public IActionResult OnGet()
    {
        byte[] id;
        if (HttpContext.Session.TryGetValue("Id", out id)) return RedirectToPage("/Main");
        return Page();
    }
}