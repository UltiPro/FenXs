using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using FenXs.DataAccessLayer.Account;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class UsersSetActiveModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    [BindProperty(SupportsGet = true)]
    public bool set { get; set; }
    private Account account;

    public UsersSetActiveModel(IConfiguration configuration, ILogger _logger)
    {
        account = new Account(configuration, _logger);
    }

    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
        if (!account.UpdateActive(id, !set)) Response.Redirect("/Error");
        Response.Redirect("../Users");
    }
}