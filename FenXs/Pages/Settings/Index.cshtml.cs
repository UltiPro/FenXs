using PageModels.LoggedPageModel;
using DAL.FenXsAccountDAL;

namespace FenXs.Pages;

public class SettingsIndexModel : LoggedPageModel
{
    private FenXsAccountDAL FAD;
    public SettingsIndexModel(IConfiguration _configuration)
    {
        FAD = new FenXsAccountDAL(_configuration);
    }
}