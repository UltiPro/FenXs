using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class NewsEditModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private FenXsNewsDAL fenXsNewsDAL;
    [BindProperty]
    public News news { get; set; }
    public List<NewsCategory> listOfNewsCategories;
    public bool dangerBox;
    public string info;
    public NewsEditModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration, iFenXsLogger);
        listOfNewsCategories = fenXsNewsDAL.GetCategories();
    }
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            news.id = id;
            if (fenXsNewsDAL.UpdateNews(news)) Response.Redirect("../News");
            else info = "Currently, the server cannot fulfill the request.";
        }
        dangerBox = true;
        OnGet();
    }
}