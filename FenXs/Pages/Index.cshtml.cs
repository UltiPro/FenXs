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
    public IndexModel()
    {
        r = new Registration();
        l = new Login();
    }
    public IActionResult OnPost([FromBody] Registration r)
    {
        /*if(ModelState["l"].Errors.Count > 0)
        {
            Console.WriteLine("r");
        }
        
        if(TryValidateModel(l))
        {
            Console.WriteLine("l");
        }*/

        if (!ModelState.IsValid)
        {
            ErrorBoxOfModels = true;
            return Page();
        }

        
        return Page();
    }
}
