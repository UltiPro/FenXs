using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using FenXs.DataAccessLayer.News;
using NewsM = FenXsData.Models.NewsModel.News;
using NewsCM = FenXsData.Models.NewsModel.NewsCategory;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class NewsAddModel : AdminPageModel
{
    private News news;
    [BindProperty]
    public NewsM? newsM { get; set; }
    public List<NewsCM> listOfNewsCategories;
    public string? info;
    public bool dangerBox;

    public NewsAddModel(IConfiguration configuration, ILogger _logger)
    {
        news = new News(configuration, _logger);
        listOfNewsCategories = news.GetCategories();
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            if (news.InsertNews(newsM!)) Response.Redirect("../News");
            else info = "Currently, the server cannot fulfill the request.";
        }
        dangerBox = true;
        OnGet();
    }
}