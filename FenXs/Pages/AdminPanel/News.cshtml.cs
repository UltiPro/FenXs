using PageModels.AdminPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;
using Infrastructure.FenXsLogger;

namespace FenXs.Pages;

public class NewsModel : AdminPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    public List<News> listOfNews;
    public List<NewsCategory> listOfNewsCategories;
    public NewsModel(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration, iFenXsLogger);
        listOfNews = fenXsNewsDAL.GetNews(false);
        listOfNewsCategories = fenXsNewsDAL.GetCategories();
    }
}