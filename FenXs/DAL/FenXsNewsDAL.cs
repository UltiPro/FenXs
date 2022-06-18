using System.Data;
using System.Data.SqlClient;
using Models.NewsModel;

namespace DAL.FenXsNewsDAL;

public class FenXsNewsDAL
{
    string connectionString;
    public FenXsNewsDAL(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("FenXs-News");
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
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
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
                    listOfNews.Add(n);
                }
                con.Close();
            }
            return listOfNews;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
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
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
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
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
            return false;
        }
    }
}