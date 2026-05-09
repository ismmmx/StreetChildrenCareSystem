using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class DBHelper
{
    // App.config থেকে নেওয়া হচ্ছে
    // Hardcode করা হচ্ছে না 
    private static string connString =
        ConfigurationManager
        .ConnectionStrings
        ["StreetChildrenDB"]
        .ConnectionString;

    // Connection দেওয়ার method
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

    // Data দেখানোর জন্য
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

    // Insert Update Delete এর জন্য
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