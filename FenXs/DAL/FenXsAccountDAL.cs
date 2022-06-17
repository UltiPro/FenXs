using System.Data;
using System.Data.SqlClient;
using Models.RegistrationModel;
using Models.LoginModel;
using Models.UserModel;

namespace DAL.FenXsAccountDAL;

public class FenXsAccountDAL
{
    string connectionString;
    public FenXsAccountDAL(IConfiguration _configuration)
    {
        connectionString = _configuration.GetConnectionString("FenXs-Account");
    }
    public int Register(Registration r)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", r.login);
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(r.password));
                cmd.Parameters.AddWithValue("@email", r.email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                if (CheckFree("CheckFreeLogin", "@login", r.login)) return 1;
                if (CheckFree("CheckFreeEmail", "@email", r.email)) return 2;
            }
            Console.WriteLine(ex.Number + " " + ex.Message);
            return ex.Number;
        }
        return 0;
    }
    private bool CheckFree(string storedProcedure, string Indicator, string value)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Indicator, value);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read()) return true;
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return false;
        }
        return false;
    }
    public UserReturn Login(Login l)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", l.login);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.Read()) return new UserReturn(null, 1);
                if (BCrypt.Net.BCrypt.Verify(l.password, rdr["Password"].ToString()))
                {
                    if (!Convert.ToBoolean(rdr["Active"])) return new UserReturn(null, 3);
                    if (Convert.ToBoolean(rdr["Banned"])) return new UserReturn(null, 4);
                    User u = new User(Convert.ToInt32(rdr["Id"]), rdr["Login"].ToString(), rdr["Email"].ToString(), Convert.ToBoolean(rdr["Admin"]), Convert.ToInt32(rdr["FenXs_stars"]));
                    return new UserReturn(u, 0);
                }
                else return new UserReturn(null, 2);
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return new UserReturn(null, -1);
        }
    }
    public int UpdateEmail(int id,string email)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return ex.Number;
        }
        return 0;
    }
    /*public int UpdatePassword(int id,string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("UpdatePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Number + " " + ex.Message);
            return ex.Number;
        }
        return 0;
    }*/
}