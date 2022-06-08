using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.UserModel;

namespace Models.LogedInPageModel;

public class LogedInPageModel : PageModel
{
    User user;
    public LogedInPageModel()
    {

    }
    public IActionResult OnGet()
    {
        //if(!HttpContext.Session.TryGetValue("Id",user.id)) RedirectToPage("Index");
        return Page();
    }
}

