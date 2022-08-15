using PageModels.AdminPageModel;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class TurnOffServerModel : AdminPageModel
{
    public TurnOffServerModel() { }
    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
    }
    public void OnPostTurnOffServerStart()
    {

    }
    public void OnPostTurnOffServerStop()
    {

    }
}