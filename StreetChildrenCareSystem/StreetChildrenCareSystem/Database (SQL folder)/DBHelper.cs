using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class DBHelper
{
    // Get from config file
    // Dynamic value 
    private static string connString =
        ConfigurationManager
        .ConnectionStrings
        ["StreetChildrenDB"]
        .ConnectionString;

    // Method to connect
    public static SqlConnection
        GetConnection()
    {
        return new SqlConnection
            (connString);
    }

    // Connection Test
    public static bool TestConnection()
    {
        try
        {
            using (SqlConnection con =
                GetConnection())
            {
                con.Open();
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Connection Failed: "
                + ex.Message);
            return false;
        }
    }

    // To show data
    public static DataTable
        GetData(string query,
        SqlParameter[] parameters
        = null)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con =
            GetConnection())
        {
            SqlCommand cmd =
                new SqlCommand
                (query, con);
            if (parameters != null)
                cmd.Parameters
                .AddRange(parameters);
            SqlDataAdapter da =
                new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    // To save, edit, or delete
    public static bool ExecuteQuery(
        string query,
        SqlParameter[] parameters
        = null)
    {
        try
        {
            using (SqlConnection con =
                GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand
                    (query, con);
                if (parameters != null)
                    cmd.Parameters
                    .AddRange(parameters);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Error: " + ex.Message);
            return false;
        }
    }
}