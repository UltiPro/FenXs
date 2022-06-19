using Microsoft.AspNetCore.Mvc;

namespace PageModels.AdminPageModel;

public class AdminPageModel : UserPageModel.UserPageModel
{
    override public IActionResult OnGet()
    {
        if (!IsUserLogged()) return RedirectToPage("/Index");
        if (!user.admin) return RedirectToPage("/Main");
        return Page();
    }
}