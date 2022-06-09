using Microsoft.AspNetCore.Mvc;
using PageModels.NotLoggedPageModel;
using DAL.FenXsAccountDAL;
using Models.RegistrationModel;
using Models.LoginModel;
using Models.UserModel;

namespace FenXs.Pages;

public class IndexModel : NotLoggedPageModel
{
    [BindProperty]
    public Registration R { get; set; }
    [BindProperty]
    public Login L { get; set; }
    private FenXsAccountDAL FAD;
    public bool ErrorBox, WarningBox, SuccessBox;
    public string Info;
    public IndexModel(IConfiguration _configuration)
    {
        FAD = new FenXsAccountDAL(_configuration);
    }
    public IActionResult OnPostLogin()
    {
        ErrorBox = WarningBox = SuccessBox = false;
        if (ModelState.ErrorCount - 4 == 0)
        {
            UserReturn UserReturn = FAD.Login(L);
            if (UserReturn.User != null)
            {
                HttpContext.Session.SetInt32("Id", UserReturn.User.Id);
                HttpContext.Session.SetString("Login", UserReturn.User.Login);
                HttpContext.Session.SetString("Email", UserReturn.User.Email);
                HttpContext.Session.SetInt32("Admin", Convert.ToInt32(UserReturn.User.Admin));
                HttpContext.Session.SetInt32("FenXs_stars", UserReturn.User.FenXs_stars);
                return RedirectToPage("Main");
            }
            switch (UserReturn.StatusCode)
            {
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
                    WarningBox = true;
                    Info = "This account is banned!";
                    break;
                case -1:
                    ErrorBox = true;
                    Info = "Page server is offline. Sorry for the inconvenience.";
                    break;
                default: return RedirectToPage("Error");
            }
        }
        else ErrorBox = true;
        return Page();
    }
    public IActionResult OnPostRegistration()
    {
        ErrorBox = WarningBox = SuccessBox = false;
        if (ModelState.ErrorCount - 2 == 0)
        {
            if (R.password != R.c_password)
            {
                ErrorBox = true;
                Info = "The passwords do not match!";
            }
            else
            {
                switch (FAD.Register(R))
                {
                    case 0:
                        SuccessBox = true;
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
                    default: return RedirectToPage("Error");
                }
            }
        }
        else ErrorBox = true;
        return Page();
    }
}