using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;
using Models.NewsModel;

namespace FenXs.Pages;

public class NewsEditModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private FenXsNewsDAL FND;
    [BindProperty]
    public News N { get; set; }
    public bool ErrorBox;
    public string Info;
    public NewsEditModel(IConfiguration _configuration)
    {
        FND = new FenXsNewsDAL(_configuration);
    }
    public IActionResult OnPost()
    {
        ErrorBox = false;
        if (ModelState.IsValid)
        {
            N.id = id;
            if (FND.UpdateNews(N)) return RedirectToPage("../News");
            else Info = "Currently, the server cannot fulfill the request.";
        }
        ErrorBox = true;
        return Page();
    }
}