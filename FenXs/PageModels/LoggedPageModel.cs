using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserModel;

namespace PageModels.LoggedPageModel;

public class LoggedPageModel : PageModel
{
    public User user;
    private byte[] Id;
    public LoggedPageModel()
    {
        user = new User();
    }
    virtual public IActionResult OnGet()
    {
        if (!IsUserLogged()) return RedirectToPage("/Index");
        return Page();
    }
    public bool IsUserLogged()
    {
        if (!HttpContext.Session.TryGetValue("Id", out Id)) return false;
        user.Id = (int)HttpContext.Session.GetInt32("Id");
        user.Login = HttpContext.Session.GetString("Login");
        user.Email = HttpContext.Session.GetString("Email");
        user.Admin = Convert.ToBoolean(HttpContext.Session.GetInt32("Admin"));
        user.FenXs_stars = (int)HttpContext.Session.GetInt32("FenXs_stars");
        return true;
    }
}