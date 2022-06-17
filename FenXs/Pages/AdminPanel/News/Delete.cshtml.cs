using Microsoft.AspNetCore.Mvc;
using PageModels.AdminPageModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class NewsDeleteModel : AdminPageModel
{
    private FenXsNewsDAL FND;
    public NewsDeleteModel(IConfiguration _configuration)
    {
        FND = new FenXsNewsDAL(_configuration);
    }
    override public IActionResult OnGet()
    {
        return RedirectToPage("../News");
    }
    public IActionResult OnGetDelete(int id)
    {
        if (!IsUserLogged()) return RedirectToPage("/Index");
        if (!IsUserAnAdmin()) return RedirectToPage("/Main");
        FND.RemoveNews(id);
        return RedirectToPage("../News");
    }
}