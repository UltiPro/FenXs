using PageModels.AdminPageModel;
using Models.NewsModel;
using DAL.FenXsNewsDAL;

namespace FenXs.Pages;

public class NewsModel : AdminPageModel
{
    private FenXsNewsDAL FND;
    public List<News> ListOfNews;
    public NewsModel(IConfiguration _configuration)
    {
        FND = new FenXsNewsDAL(_configuration);
        ListOfNews = FND.GetNews(false);
    }
}