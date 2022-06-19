using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserModel;

namespace PageModels.UserPageModel;

public class UserPageModel : PageModel
{
    public User user;
    public UserPageModel()
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
        byte[] id;
        if (HttpContext.Session.TryGetValue("Id", out id))
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