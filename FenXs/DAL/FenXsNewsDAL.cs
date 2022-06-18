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
    public int InsertNews(News n)
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
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
            return -1;
        }
        return 0;
    }
    public List<News> GetNews(bool onlyTen)
    {
        List<News> listOfNews = new List<News>();
        try
        {
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
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
            return null;
        }
        return listOfNews;
    }
    public int RemoveNews(int id)
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
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
            return -1;
        }
        return 0;
    }
    public int UpdateNews(News n)
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
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Number + " " + e.Message); //Change to logs
            return -1;
        }
        return 0;
    }
}