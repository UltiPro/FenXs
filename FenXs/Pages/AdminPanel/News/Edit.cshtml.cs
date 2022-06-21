using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;
using Models.NewsModel;

namespace FenXs.Pages;

public class NewsEditModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private FenXsNewsDAL fenXsNewsDAL;
    [BindProperty]
    public News news { get; set; }
    public bool dangerBox;
    public string info;
    public NewsEditModel(IConfiguration configuration)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration);
    }
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            news.id = id;
            if (fenXsNewsDAL.UpdateNews(news)) return RedirectToPage("../News");
            else info = "Currently, the server cannot fulfill the request.";
        }
        dangerBox = true;
        return Page();
    }
}