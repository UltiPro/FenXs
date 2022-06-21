using PageModels.AdminPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class NewsModel : AdminPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    public List<News> listOfNews;
    public List<NewsCategory> listOfNewsCategories;
    public NewsModel(IConfiguration configuration)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration);
        listOfNews = fenXsNewsDAL.GetNews(false);
        listOfNewsCategories = fenXsNewsDAL.GetCategories();
    }
}