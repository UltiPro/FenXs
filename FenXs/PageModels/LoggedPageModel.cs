using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserModel;

namespace PageModels.LoggedPageModel;

public class LoggedPageModel : PageModel
{
    public User user;
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
        if (User.Identity.IsAuthenticated)
        {
            user.id = (int)HttpContext.Session.GetInt32("Id");
            user.login = HttpContext.Session.GetString("Login");
            user.email = HttpContext.Session.GetString("Email");
            user.admin = Convert.ToBoolean(HttpContext.Session.GetInt32("Admin"));
            user.fenXs_Stars = (int)HttpContext.Session.GetInt32("FenXs_stars");
            return true;
        }
        return false;
    }
}