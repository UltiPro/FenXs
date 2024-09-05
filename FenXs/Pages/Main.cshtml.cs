using PageModels.UserPageModel;
using NewsM = FenXsData.Models.NewsModel.News;
using FenXs.DataAccessLayer.News;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class MainModel : UserPageModel
{
    private News news;
    public List<NewsM> listOfNews;

    public MainModel(IConfiguration configuration, ILogger _logger)
    {
        news = new News(configuration, _logger);
        listOfNews = news.GetNews(true);
    }
}