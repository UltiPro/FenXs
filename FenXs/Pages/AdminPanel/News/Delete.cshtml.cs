using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class NewsDeleteModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private FenXsNewsDAL fenXsNewsDAL;
    public NewsDeleteModel(IConfiguration configuration)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration);
    }
    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/Index");
        if (!user.admin) Response.Redirect("/Main");
        if (!fenXsNewsDAL.RemoveNews(id)) Response.Redirect("/Error");
        Response.Redirect("../News");
    }
}