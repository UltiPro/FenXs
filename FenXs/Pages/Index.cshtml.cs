using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.FenXsAccountDAL;
using Models.RegistrationModel;
using Models.LoginModel;
using Models.UserModel;

namespace FenXs.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Registration r { get; set; }
    [BindProperty]
    public Login l { get; set; }
    private FenXsAccountDAL FAD;
    public bool ErrorBox, WarningBox, SuccessBox;
    public string Info;
    public IndexModel(IConfiguration _configuration)
    {
        FAD = new FenXsAccountDAL(_configuration);
    }
    public void OnPost()
    {
        Register();
        Login();
    }
    private bool ValidateRegistration()
    {
        if (r.login == "" || r.login == null) return false;
        if (r.email == "" || r.email == null) return false;
        if (r.password == "" || r.password == null) return false;
        if (r.c_password == "" || r.c_password == null) return false;
        if (r.c_password != r.password)
        {
            Info = "Passwords must be the same!";
            return false;
        }
        return true;
    }
    private IActionResult Register()
    {
        if (ValidateRegistration())
        {
            ErrorBox = WarningBox = SuccessBox = false;
            switch (FAD.Register(r))
            {
                case 0:
                    SuccessBox = true;
                    Response.Cookies.Append("Visited", "1");
                    Info = "A link to activate the account has been sent to the given e-mail address.";
                    break;
                case 1:
                    WarningBox = true;
                    Info = "This Login is already taken.";
                    break;
                case 2:
                    WarningBox = true;
                    Info = "This Email is already in use.";
                    break;
                case -1:
                    ErrorBox = true;
                    Info = "Page server is offline. Sorry for the inconvenience.";
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
    private bool ValidateLogin()
    {
        if (l.login == "" || l.login == null) return false;
        if (l.password == "" || l.password == null) return false;
        return true;
    }
    public IActionResult Login()
    {
        //HttpContext.Session.SetInt32("id",u.id);
        //HttpContext.Session.SetString("login", u.login);
        if (ValidateLogin())
        {
            ErrorBox = WarningBox = SuccessBox = false;
            UserReturn u = FAD.Login(l);
            switch (u.statusCode)
            {
                case 0:
                    Response.Cookies.Append("Visited", "1");
                    RedirectToPage("Main");
                    break;
                case 1:
                    WarningBox = true;
                    Info = "Account with this login does not exist.";
                    break;
                case 2:
                    WarningBox = true;
                    Info = "Incorrect password.";
                    break;
                case 3:
                    WarningBox = true;
                    Info = "This account is not activated.";
                    break;
                case 4:
                    ErrorBox = true;
                    Info = "This account is banned!";
                    break;
                case -1:
                    ErrorBox = true;
                    Info = "Page server is offline. Sorry for the inconvenience.";
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
}
