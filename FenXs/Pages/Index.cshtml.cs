using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Registration;
using Models.Login;
using DAL.FenXsAccountDAL;

namespace FenXs.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Registration r { get; set; }
    [BindProperty]
    public Login l { get; set; }
    private FenXsAccountDAL FAD;
    public bool ErrorBox,WarningBox,SuccessBox;
    public string Info;
    public IndexModel(IConfiguration _configuration)
    {
        FAD = new FenXsAccountDAL(_configuration);
    }
    public IActionResult OnPost()
    {
        if(ValidateRegistration())
        {
            ErrorBox = WarningBox = SuccessBox = false;
            switch(FAD.AddNewUser(r))
            {
                case 0:
                    SuccessBox=true;
                    Info="A link to activate the account has been sent to the given e-mail address.";
                break;
                case 1:
                    WarningBox=true;
                    Info="This Login is already taken.";
                break;
                case 2:
                    WarningBox=true;
                    Info="This Email is already in use.";
                break;
                case -1:
                    ErrorBox=true;
                    Info="Page server is offline. Sorry for the inconvenience.";
                break;
                default:
                    RedirectToPage("Error");
                break;
            }
            return Page();
        }
        ErrorBox = true;
        return Page();
    }
    private bool ValidateRegistration()
    {
        if(r.login==""||r.login==null) return false;
        if(r.email==""||r.email==null) return false;
        if(r.password==""||r.password==null) return false;
        if(r.c_password==""||r.c_password==null) return false;
        if(r.c_password!=r.password) 
        {
            Info = "Passwords must be the same!";
            return false;
        }
        return true;
    }
    private bool ValidateLogin()
    {
        if(l.login==""||l.login==null) return false;
        if(l.password==""||l.password==null) return false;
        return true;
    }
}
