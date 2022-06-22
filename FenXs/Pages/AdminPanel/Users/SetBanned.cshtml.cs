using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsAccountDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class UsersSetBannedModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    [BindProperty(SupportsGet = true)]
    public bool set { get; set; }
    private FenXsAccountDAL fenXsAccountDAL;
    public UsersSetBannedModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsAccountDAL = new FenXsAccountDAL(configuration, iFenXsLogger);
    }
    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
        if (!fenXsAccountDAL.UpdateBanned(id, !set)) Response.Redirect("/Error");
        Response.Redirect("../Users");
    }
}