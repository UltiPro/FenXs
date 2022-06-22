using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class NewsAddModel : AdminPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    [BindProperty]
    public News news { get; set; }
    public List<NewsCategory> listOfNewsCategories;
    public bool dangerBox;
    public string info;
    public NewsAddModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration, iFenXsLogger);
        listOfNewsCategories = fenXsNewsDAL.GetCategories();
    }
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            if (fenXsNewsDAL.InsertNews(news)) Response.Redirect("../News");
            else info = "Currently, the server cannot fulfill the request.";
        }
        dangerBox = true;
        OnGet();
    }
}