using PageModels.AdminPageModel;
using NewsM = FenXsData.Models.NewsModel.News;
using NewsCM = FenXsData.Models.NewsModel.NewsCategory;
using FenXs.DataAccessLayer.News;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.Pages;

public class NewsModel : AdminPageModel
{
    private News news;
    public List<NewsM> listOfNews;
    public List<NewsCM> listOfNewsCategories;

    public NewsModel(IConfiguration configuration, ILogger _logger)
    {
        news = new News(configuration, _logger);
        listOfNews = news.GetNews(false);
        listOfNewsCategories = news.GetCategories();
    }
}