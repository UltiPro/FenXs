using PageModels.UserPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class MainModel : UserPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    public List<News> listOfNews;
    public MainModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration, iFenXsLogger);
        listOfNews = fenXsNewsDAL.GetNews(true);
    }
}