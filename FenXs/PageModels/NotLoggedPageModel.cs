using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels.NotLoggedPageModel;

public class NotLoggedPageModel : PageModel
{
    private byte[] Id;
    public IActionResult OnGet()
    {
        if (HttpContext.Session.TryGetValue("Id", out Id)) return RedirectToPage("/Main");
        return Page();
    }
}