using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels.NotLoggedPageModel;

public class NotLoggedPageModel : PageModel
{
    private byte[] id;
    public IActionResult OnGet()
    {
        if (HttpContext.Session.TryGetValue("Id", out id)) return RedirectToPage("/Main");
        return Page();
    }
}