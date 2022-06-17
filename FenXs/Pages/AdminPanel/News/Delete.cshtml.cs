using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class NewsDeleteModel : AdminPageModel
{
    [BindProperty(SupportsGet = true)]
    public int id { get; set; }
    private FenXsNewsDAL FND;
    public NewsDeleteModel(IConfiguration _configuration)
    {
        FND = new FenXsNewsDAL(_configuration);
    }
    override public IActionResult OnGet()
    {
        if (!IsUserLogged()) return RedirectToPage("/Index");
        if (!IsUserAnAdmin()) return RedirectToPage("/Main");
        if (FND.RemoveNews(id) != 0) return RedirectToPage("/Error");
        return RedirectToPage("../News");
    }
}