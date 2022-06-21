using System.Data;
using System.Data.SqlClient;
using Models.NewsModel;
using Infrastructure.FenXsLogger;

namespace DAL.FenXsNewsDAL;

public class FenXsNewsDAL
{
    private IFenXsLogger iFenXsLogger;
    string connectionString;
    public FenXsNewsDAL(IConfiguration configuration, IFenXsLogger iFenXsLogger)
    {
        connectionString = configuration.GetConnectionString("FenXs-News");
        this.iFenXsLogger = iFenXsLogger;
    }
    public bool InsertNews(News n)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
            iFenXsLogger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }
    public List<News> GetNews(bool onlyTen)
    {
        try
        {
            List<News> listOfNews = new List<News>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (onlyTen) cmd = new SqlCommand("GetTenNews", con);
                else cmd = new SqlCommand("GetAllNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    News n = new News();
                    n.id = Convert.ToInt32(r["Id"]);
                    n.date = Convert.ToDateTime(r["Date"]);
                    n.title = r["Title"].ToString();
                    n.text = r["Text"].ToString();
                    n.idOfCategory = Convert.ToInt32(r["IdOfCategory"]);
                    listOfNews.Add(n);
                }
                con.Close();
            }
            return listOfNews;
        }
        catch (SqlException e)
        {
            iFenXsLogger.SaveLog(e.Number + " " + e.Message);
            return null;
        }
    }
    public bool RemoveNews(int id)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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
            iFenXsLogger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }
    public bool UpdateNews(News n)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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
            iFenXsLogger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }
    public List<NewsCategory> GetCategories()
    {
        try
        {
            List<NewsCategory> listOfCategories = new List<NewsCategory>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    NewsCategory nc = new NewsCategory();
                    nc.id = Convert.ToInt32(r["Id"]);
                    nc.name = r["Name"].ToString();
                    listOfCategories.Add(nc);
                }
                con.Close();
            }
            return listOfCategories;
        }
        catch (SqlException e)
        {
            iFenXsLogger.SaveLog(e.Number + " " + e.Message);
            return null;
        }
    }
}