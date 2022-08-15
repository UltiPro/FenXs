using System.Diagnostics;
using PageModels.AdminPageModel;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class TurnOffServerModel : AdminPageModel
{
    private IFenXsLogger iFenXsLogger;
    public TurnOffServerModel(IFenXsLogger iFenXsLogger)
    {
        this.iFenXsLogger = iFenXsLogger;
    }
    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
    }
    public void OnPostTurnOffServerStart()
    {
        try
        {
            Process.Start("D:\\Scripts\\TurnOffServerStart.exe");
        }
        catch (Exception ex)
        {
            iFenXsLogger.SaveLog(ex.Message);
        }
    }
    public void OnPostTurnOffServerStop()
    {
        try
        {
            Process.Start("D:\\Scripts\\TurnOffServerStop.exe");
        }
        catch (Exception ex)
        {
            iFenXsLogger.SaveLog(ex.Message);
        }
    }
}