using Microsoft.AspNetCore.Mvc;
using PageModels.UserPageModel;
using Models.ChangeEmailModel;
using Models.ChangePasswordModel;
using Models.RemoveAccountModel;
using DAL.FenXsAccountDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class SettingsIndexModel : UserPageModel
{
    private FenXsAccountDAL fenXsAccountDAL;
    [BindProperty]
    public ChangeEmail ce { get; set; }
    [BindProperty]
    public ChangePassword cp { get; set; }
    [BindProperty]
    public RemoveAccount ra { get; set; }
    public bool dangerBox, warningBox, successBox;
    public string info;
    public SettingsIndexModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsAccountDAL = new FenXsAccountDAL(configuration, iFenXsLogger);
    }
    public void OnPostChangeEmail()
    {
        successBox = warningBox = dangerBox = false;
        if (ModelState.ErrorCount - 4 == 0)
        {
            if (!(String.Compare(ce.oldEmail, HttpContext.Session.GetString("email")) == 0))
            {
                dangerBox = true;
                info = "Wrong old email provided.";
            }
            else if (String.Compare(ce.oldEmail, ce.newEmail) == 0)
            {
                warningBox = true;
                info = "The new email address cannot be the same as the old email address.";
            }
            else
            {
                switch (fenXsAccountDAL.UpdateEmail((int)HttpContext.Session.GetInt32("id"), ce.newEmail))
                {
                    case 0:
                        successBox = true;
                        info = "Your email has been successfully changed.";
                        HttpContext.Session.Remove("email");
                        HttpContext.Session.SetString("email", ce.newEmail);
                        break;
                    case 1:
                        warningBox = true;
                        info = "This email is already taken.";
                        break;
                    case -1:
                        dangerBox = true;
                        info = "The server was unable to process the request. Sorry for the inconvenience.";
                        break;
                }
            }
        }
        else dangerBox = true;
        OnGet();
    }
    public void OnPostChangePassword()
    {
        successBox = warningBox = dangerBox = false;
        if (ModelState.ErrorCount - 4 == 0)
        {
            if (!fenXsAccountDAL.CheckPasswordCompatibility((int)HttpContext.Session.GetInt32("id"), cp.oldPassword))
            {
                dangerBox = true;
                info = "Wrong old password provided.";
            }
            else
            {
                switch (fenXsAccountDAL.UpdatePassword((int)HttpContext.Session.GetInt32("id"), cp.newPassword))
                {
                    case true:
                        successBox = true;
                        info = "Your password has been successfully changed.";
                        break;
                    case false:
                        dangerBox = true;
                        info = "The server was unable to process the request. Sorry for the inconvenience.";
                        break;
                }
            }
        }
        else dangerBox = true;
        OnGet();
    }
    public void OnPostRemoveAccount()
    {
        successBox = warningBox = dangerBox = false;
        if (ModelState.ErrorCount - 6 == 0)
        {
            if (!fenXsAccountDAL.CheckPasswordCompatibility((int)HttpContext.Session.GetInt32("id"), ra.password))
            {
                dangerBox = true;
                info = "Wrong password provided.";
            }
            else
            {
                switch (fenXsAccountDAL.RemoveUser((int)HttpContext.Session.GetInt32("id")))
                {
                    case true:
                        Response.Redirect("/Logout");
                        break;
                    case false:
                        dangerBox = true;
                        info = "The server was unable to process the request. Sorry for the inconvenience.";
                        break;
                }
            }
        }
        else dangerBox = true;
        OnGet();
    }
}