using PageModels.AdminPageModel;
using FenXs.DataAccessLayer.Account;
using UserFull = FenXsData.Models.UserModel.UserFull;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class UsersModel : AdminPageModel
{
    private Account account;
    public List<UserFull> listOfUsers;

    public UsersModel(IConfiguration configuration, ILogger _logger)
    {
        account = new Account(configuration, _logger);
        listOfUsers = account.GetAllUsers();
    }
}