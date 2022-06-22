using Microsoft.AspNetCore.Mvc;

using PageModels.AdminPageModel;
using Models.UserModel;
using DAL.FenXsAccountDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class UsersModel : AdminPageModel
{
    private FenXsAccountDAL fenXsAccountDAL;
    public List<UserFULL> listOfUsers;
    public UsersModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsAccountDAL = new FenXsAccountDAL(configuration, iFenXsLogger);
        listOfUsers = fenXsAccountDAL.GetAllUsers();
    }
}