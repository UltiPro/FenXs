using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using FenXs.DataAccessLayer.News;
using ILogger = FenXsData.Infrastructure.Logger;

namespace FenXs.Pages;

public class NewsDeleteModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private News news;

    public NewsDeleteModel(IConfiguration configuration, ILogger.ILogger _logger)
    {
        news = new News(configuration, _logger);
    }

    override public void OnGet()
    {
        if (!IsUserLogged()) Response.Redirect("/");
        if (!user.admin) Response.Redirect("/Main");
        if (!news.RemoveNews(id)) Response.Redirect("/Error");
        Response.Redirect("../News");
    }
}