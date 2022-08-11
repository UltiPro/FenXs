using PageModels.AdminPageModel;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class TurnOffServerModel : AdminPageModel
{
    string connectionString;
    public TurnOffServerModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        
    }
}