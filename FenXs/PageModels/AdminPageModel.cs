using Microsoft.AspNetCore.Mvc;

namespace PageModels.AdminPageModel;

public class AdminPageModel : LoggedPageModel.LoggedPageModel
{
    override public IActionResult OnGet()
    {
        if (!IsUserLogged()) return RedirectToPage("/Index");
        if (!IsUserAnAdmin()) return RedirectToPage("/Main");
        return Page();
    }
    public bool IsUserAnAdmin()
    {
        return user.Admin;
    }
}