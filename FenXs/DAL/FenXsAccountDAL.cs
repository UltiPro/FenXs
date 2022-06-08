using System.Data;
using System.Data.SqlClient;
using Models.Registration;

namespace DAL.FenXsAccountDAL;

public class FenXsAccountDAL
{
    string connectionString;
    public FenXsAccountDAL(IConfiguration _configuration)
    {
        connectionString = _configuration.GetConnectionString("FenXs-Account");
    }
    public int AddNewUser(Registration r)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(r.password);
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", r.login);
                cmd.Parameters.AddWithValue("@password", passwordHash);
                cmd.Parameters.AddWithValue("@email", r.email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (SqlException ex)
        {
            if(ex.Number==2627)
            {
                if (CheckFree("CheckFreeLogin", "@login", r.login)) return 1;
                if (CheckFree("CheckFreeEmail", "@email", r.email)) return 2;
            }
            Console.WriteLine(ex.Number + " " + ex.Message);
            return ex.Number;
        }
        return 0;
    }
    private bool CheckFree(string storedProcedure, string Indicator, string value) //bzydkie
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
            Console.WriteLine(ex.Number);
            return false;
        }
        return false;
    }
}