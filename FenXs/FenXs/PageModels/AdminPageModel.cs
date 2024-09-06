namespace PageModels.AdminPageModel;

public class AdminPageModel : UserPageModel.UserPageModel
{
    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
    }
}