using System.Data;
using System.Data.SqlClient;
using NewsModel = FenXsData.Models.NewsModel.News;
using NewsCategory = FenXsData.Models.NewsModel.NewsCategory;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;

namespace FenXs.DataAccessLayer.News;

public class News
{
    private ILogger _logger;
    private string _connectionString;

    public News(IConfiguration configuration, ILogger _logger)
    {
        _connectionString = configuration.GetConnectionString("FenXs")!;
        this._logger = _logger;
    }

    public bool InsertNews(NewsModel news)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", news.title);
                cmd.Parameters.AddWithValue("@text", news.text);
                cmd.Parameters.AddWithValue("@idOfCategory", news.idOfCategory);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }

    public List<NewsModel> GetNews(bool onlyTen)
    {
        try
        {
            List<NewsModel> listOfNews = new List<NewsModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd;
                if (onlyTen) cmd = new SqlCommand("GetTenNews", con);
                else cmd = new SqlCommand("GetAllNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    NewsModel n = new NewsModel();
                    n.id = Convert.ToInt32(r["Id"]);
                    n.date = Convert.ToDateTime(r["Date"]);
                    n.title = r["Title"].ToString() ?? "---";
                    n.text = r["Text"].ToString() ?? "---";
                    n.idOfCategory = Convert.ToInt32(r["IdOfCategory"]);
                    listOfNews.Add(n);
                }
                con.Close();
            }
            return listOfNews;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return null;
        }
    }

    public bool RemoveNews(int id)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("RemoveNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }

    public bool UpdateNews(NewsModel n)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", n.id);
                cmd.Parameters.AddWithValue("@title", n.title);
                cmd.Parameters.AddWithValue("@text", n.text);
                cmd.Parameters.AddWithValue("@idOfCategory", n.idOfCategory);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }

    public List<NewsCategory> GetCategories()
    {
        try
        {
            List<NewsCategory> listOfCategories = new List<NewsCategory>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    NewsCategory nc = new NewsCategory();
                    nc.id = Convert.ToInt32(r["Id"]);
                    nc.name = r["Name"].ToString() ?? "---";
                    listOfCategories.Add(nc);
                }
                con.Close();
            }
            return listOfCategories;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return new List<NewsCategory>();
        }
    }
}