using PageModels.UserPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class MainModel : UserPageModel
{
    private FenXsNewsDAL FND;
    public List<News> ListOfNews;
    public MainModel(IConfiguration _configuration)
    {
        FND = new FenXsNewsDAL(_configuration);
        ListOfNews = FND.GetNews(true);
    }
}