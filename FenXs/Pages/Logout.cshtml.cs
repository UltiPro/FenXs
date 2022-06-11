using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FenXs.Pages;

public class LogoutModel : PageModel
{
    public IActionResult OnGet()
    {
        HttpContext.Session.Remove("Id");
        HttpContext.Session.Remove("Login");
        HttpContext.Session.Remove("Email");
        HttpContext.Session.Remove("Admin");
        HttpContext.Session.Remove("FenXs_stars");
        return RedirectToPage("/Index");
    }
}
