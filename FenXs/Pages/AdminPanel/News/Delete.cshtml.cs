using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class NewsDeleteModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private FenXsNewsDAL fenXsNewsDAL;
    public NewsDeleteModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration, iFenXsLogger);
    }
    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
        if (!fenXsNewsDAL.RemoveNews(id)) Response.Redirect("/Error");
        Response.Redirect("../News");
    }
}