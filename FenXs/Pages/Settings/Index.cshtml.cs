using PageModels.UserPageModel;
using DAL.FenXsAccountDAL;

namespace FenXs.Pages;

public class SettingsIndexModel : UserPageModel
{
    private FenXsAccountDAL FAD;
    public SettingsIndexModel(IConfiguration _configuration)
    {
        FAD = new FenXsAccountDAL(_configuration);
    }
}