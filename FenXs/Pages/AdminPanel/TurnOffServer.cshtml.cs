using System.Diagnostics;
using PageModels.AdminPageModel;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class TurnOffServerModel : AdminPageModel
{
    private ILogger _logger;

    public TurnOffServerModel(ILogger _logger)
    {
        this._logger = _logger;
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
            _logger.SaveLog(ex.Message);
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
            _logger.SaveLog(ex.Message);
        }
    }
}