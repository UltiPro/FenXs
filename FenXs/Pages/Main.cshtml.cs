using PageModels.UserPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class MainModel : UserPageModel
{
    private FenXsNewsDAL fenXsNewsDAL;
    public List<News> listOfNews;
    public MainModel(IConfiguration configuration)
    {
        fenXsNewsDAL = new FenXsNewsDAL(configuration);
        listOfNews = fenXsNewsDAL.GetNews(true);
    }
}