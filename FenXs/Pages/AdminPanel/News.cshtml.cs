using PageModels.AdminPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class NewsModel : AdminPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    public List<News> listOfNews;
    public NewsModel(IConfiguration configuration)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration);
        listOfNews = fenXsNewsDAL.GetNews(false);
    }
}