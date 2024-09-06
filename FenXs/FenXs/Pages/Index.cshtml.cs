using Microsoft.AspNetCore.Mvc;
using PageModels.VisitorPageModel;
using FenXsData.Models.RegistrationModel;
using FenXsData.Models.LoginModel;
using FenXsData.Models.UserModel;
using FenXs.DataAccessLayer.Account;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class IndexModel : VisitorPageModel
{
    [BindProperty]
    public Registration? r { get; set; }
    [BindProperty]
    public Login? l { get; set; }
    private Account account;
    public bool dangerBox, warningBox, successBox;
    public string? info;

    public IndexModel(IConfiguration configuration, ILogger _logger)
    {
        account = new Account(configuration, _logger);
    }

    public IActionResult OnPostLogin()
    {
        dangerBox = warningBox = successBox = false;
        if (ModelState.ErrorCount - 4 == 0)
        {
            UserReturn userReturn = account.GetUser(l!);
            if (userReturn.user != null)
            {
                HttpContext.Session.SetInt32("id", userReturn.user.id);
                HttpContext.Session.SetString("login", userReturn.user.login);
                HttpContext.Session.SetString("email", userReturn.user.email);
                HttpContext.Session.SetInt32("admin", Convert.ToInt32(userReturn.user.admin));
                HttpContext.Session.SetInt32("fenXs_Stars", userReturn.user.fenxsStars);
                Response.Cookies.Append("whereLogged", "1");
                return RedirectToPage("/Main");
            }
            switch (userReturn.statusCode)
            {
                case 1:
                    warningBox = true;
                    info = "Account with this login does not exist.";
                    break;
                case 2:
                    warningBox = true;
                    info = "Incorrect password.";
                    break;
                case 3:
                    warningBox = true;
                    info = "This account is not activated.";
                    break;
                case 4:
                    warningBox = true;
                    info = "This account is banned.";
                    break;
                case -1:
                    dangerBox = true;
                    info = "Page server is offline. Sorry for the inconvenience.";
                    break;
                default: return RedirectToPage("/Error");
            }
        }
        else dangerBox = true;
        return Page();
    }

    public IActionResult OnPostRegistration()
    {
        dangerBox = warningBox = successBox = false;
        if (ModelState.ErrorCount - 2 == 0)
        {
            switch (account.InsertUser(r!))
            {
                case 0:
                    successBox = true;
                    info = "A link to activate the account has been sent to the given e-mail address.";
                    Response.Cookies.Append("whereLogged", "1");
                    break;
                case 1:
                    warningBox = true;
                    info = "This Login is already taken.";
                    break;
                case 2:
                    warningBox = true;
                    info = "This Email is already taken.";
                    break;
                case -1:
                    dangerBox = true;
                    info = "Page server is offline. Sorry for the inconvenience.";
                    break;
                default: return RedirectToPage("/Error");
            }
        }
        else dangerBox = true;
        return Page();
    }
}