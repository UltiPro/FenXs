using System.Data;
using System.Data.SqlClient;
using Models.NewsModel;

namespace DAL.FenXsNewsDAL;

public class FenXsNewsDAL
{
    string connectionString;
    public FenXsNewsDAL(IConfiguration _configuration)
    {
        connectionString = _configuration.GetConnectionString("FenXs-News");
    }
    public int AddNews(News N)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", N.title);
                cmd.Parameters.AddWithValue("@text", N.text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return -1;
        }
        return 0;
    }
    public List<News> GetNews(bool OnlyTen)
    {
        List<News> listOfNews = new List<News>();
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (OnlyTen) cmd = new SqlCommand("GetTenNews", con);
                else cmd = new SqlCommand("GetAllNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    News n = new News();
                    n.id = Convert.ToInt32(rdr["Id"]);
                    n.date = Convert.ToDateTime(rdr["Date"]);
                    n.title = rdr["Title"].ToString();
                    n.text = rdr["Text"].ToString();
                    listOfNews.Add(n);
                }
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
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
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return -1;
        }
        return 0;
    }
    public int UpdateNews(News N)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateNews", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", N.id);
                cmd.Parameters.AddWithValue("@title", N.title);
                cmd.Parameters.AddWithValue("@text", N.text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return -1;
        }
        return 0;
    }
}