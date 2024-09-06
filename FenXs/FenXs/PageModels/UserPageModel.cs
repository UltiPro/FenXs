using Microsoft.AspNetCore.Mvc.RazorPages;
using FenXsData.Models.UserModel;

namespace PageModels.UserPageModel;

public class UserPageModel : PageModel
{
    public User user;

    public UserPageModel()
    {
        user = new User();
    }

    virtual public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
    }

    public bool IsUserLogged()
    {
        byte[] id;
        if (HttpContext.Session.TryGetValue("id", out id!))
        {
            user.id = (int)HttpContext.Session.GetInt32("id")!;
            user.login = HttpContext.Session.GetString("login")!;
            user.email = HttpContext.Session.GetString("email")!;
            user.admin = Convert.ToBoolean(HttpContext.Session.GetInt32("admin"))!;
            user.fenxsStars = (int)HttpContext.Session.GetInt32("fenXs_Stars")!;
            return true;
        }
        return false;
    }
}