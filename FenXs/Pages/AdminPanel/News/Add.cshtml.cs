using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;
using Models.NewsModel;

namespace FenXs.Pages;

public class NewsAddModel : AdminPageModel
{
    private FenXsNewsDAL FND;
    [BindProperty]
    public News N { get; set; }
    public bool ErrorBox;
    public string Info;
    public NewsAddModel(IConfiguration _configuration)
    {
        FND = new FenXsNewsDAL(_configuration);
    }
    public IActionResult OnPost()
    {
        ErrorBox = false;
        if (ModelState.IsValid)
        {
            if (FND.InsertNews(N) == 0) return RedirectToPage("../News");
            else Info = "Currently, the server cannot fulfill the request.";
        }
        ErrorBox = true;
        return Page();
    }
}