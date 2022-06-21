using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;
using Models.NewsModel;

namespace FenXs.Pages;

public class NewsAddModel : AdminPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    [BindProperty]
    public News news { get; set; }
    public List<NewsCategory> listOfNewsCategories;
    public bool dangerBox;
    public string info;
    public NewsAddModel(IConfiguration configuration)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration);
        listOfNewsCategories = fenXsNewsDAL.GetCategories();
    }
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            if (fenXsNewsDAL.InsertNews(news)) return RedirectToPage("../News");
            else info = "Currently, the server cannot fulfill the request.";
        }
        dangerBox = true;
        return Page();
    }
}