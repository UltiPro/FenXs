using System.Data;
using System.Data.SqlClient;
using FenXsData.Models.RegistrationModel;
using FenXsData.Models.LoginModel;
using FenXsData.Models.UserModel;
using ILogger = FenXsData.Infrastructure.Logger.ILogger;
using UserFull = FenXsData.Models.UserModel.UserFull;

namespace FenXs.DataAccessLayer.Account;

public class Account
{
    private ILogger _logger;
    private string _connectionString;

    public Account(IConfiguration configuration, ILogger _logger)
    {
        _connectionString = configuration.GetConnectionString("FenXs")!;
        this._logger = _logger;
    }

    public int InsertUser(Registration r)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", r.login);
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(r.password));
                cmd.Parameters.AddWithValue("@email", r.email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;
        }
        catch (SqlException e)
        {
            if (e.Number == 2627)
            {
                if (Check("Users_CheckLogin", "@login", r.login)) return 1;
                if (Check("Users_CheckEmail", "@email", r.email)) return 2;
            }
            _logger.SaveLog(e.Number + " " + e.Message);
            return -1;
        }
    }

    private bool Check(string storedProcedure, string indicator, string value)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(indicator, value);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read()) return true;
                con.Close();
            }
            return false;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }

    public UserReturn GetUser(Login l)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", l.login);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (!r.Read()) return new UserReturn(null!, 1);
                if (BCrypt.Net.BCrypt.Verify(l.password, r["Password"].ToString()))
                {
                    if (!Convert.ToBoolean(r["Active"])) return new UserReturn(null!, 3);
                    if (Convert.ToBoolean(r["Banned"])) return new UserReturn(null!, 4);
                    User user = new User(Convert.ToInt32(r["Id"]), r["Login"].ToString()!, r["Email"].ToString()!, Convert.ToBoolean(r["Admin"]), Convert.ToBoolean(r["Moderator"]), Convert.ToInt32(r["FenXs_stars"]));
                    return new UserReturn(user, 0);
                }
                else return new UserReturn(null!, 2);
            }
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return new UserReturn(null!, -1);
        }
    }

    public User GetUserById(int id)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetUserById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                return new User(Convert.ToInt32(r["Id"]), r["Login"].ToString()!, r["Email"].ToString()!, Convert.ToBoolean(r["Admin"]), Convert.ToBoolean(r["Moderator"]), Convert.ToInt32(r["FenXs_stars"]));
            }
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return null!;
        }
    }

    public List<UserFull> GetAllUsers()
    {
        try
        {
            List<UserFull> listOfUsers = new List<UserFull>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    UserFull userFull = new UserFull(Convert.ToInt32(r["Id"]), r["Login"].ToString()!, r["Email"].ToString()!, Convert.ToBoolean(r["Admin"]), Convert.ToBoolean(r["Moderator"]), Convert.ToInt32(r["FenXs_stars"]), Convert.ToBoolean(r["Active"]), Convert.ToBoolean(r["Banned"]), Convert.ToDateTime(r["SignInDate"]), Convert.ToDateTime(r["LastLogin"]));
                    listOfUsers.Add(userFull);
                }
                con.Close();
            }
            return listOfUsers;
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return null!;
        }
    }

    public bool CheckPasswordCompatibility(int id, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                if (BCrypt.Net.BCrypt.Verify(password, r["Password"].ToString())) return true;
                return false;
            }
        }
        catch (SqlException e)
        {
            _logger.SaveLog(e.Number + " " + e.Message);
            return false;
        }
    }

    public int UpdateEmail(int id, string email)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdateEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;
        }
        catch (SqlException e)
        {
            if (e.Number == 2627) return 1;
            _logger.SaveLog(e.Number + " " + e.Message);
            return -1;
        }
    }

    public bool UpdatePassword(int id, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdatePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password));
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

    public bool UpdateAdmin(int id, bool set)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdateAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@set", set);
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

    public bool UpdateBanned(int id, bool set)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdateBanned", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@set", set);
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

    public bool UpdateActive(int id, bool set)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdateActive", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@set", set);
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

    public bool UpdateModerator(int id, bool set)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdateModerator", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@set", set);
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

    public bool RemoveUser(int id)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_RemoveUser", con);
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
}