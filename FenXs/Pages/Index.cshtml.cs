using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Registration;
using Models.Login;

namespace FenXs.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Registration r { get; set; }
    [BindProperty]
    public Login l { get; set; }
    public bool ErrorBoxOfModels;
    public IActionResult OnPost()
    {

        if(r!=null) Console.WriteLine(r.login+" "+r.email+" "+r.password+" "+r.c_password);

        if(!ModelState.IsValid)
        {
            ErrorBoxOfModels = true;
            return Page();
        }

        return RedirectToPage("Registration");
    }

    /*private bool ValidateRegistration()
    {
        if(!TryValidateModel(r,nameof(Registration))) 
        {
            Console.WriteLine("val");
            return false;
        }
        if(r.password!=r.c_password) 
        {
            Console.WriteLine("===");
            return false;
        }

        Console.WriteLine(r.login);

        return true;
    }*/
}
