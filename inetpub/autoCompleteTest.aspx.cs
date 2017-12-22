using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

public partial class autoCompleteTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    
    protected void SearchByTagButton_Click(object sender, EventArgs e)
    {
         
        string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        SqlCommand command = new SqlCommand("usp_findPerson", conn);

            command.CommandType = CommandType.StoredProcedure;

        try
        {

            //String fname;
            //List<String> names = new List<string>();
            
            //String FirstName = "%" + tbFirstName.Text.Trim() + "%";
            //String LastName =  "%" + tbLastName.Text.Trim() + "%";
            //Date BirthDate = tbBirthDate;

            command.Parameters.Add(new SqlParameter("@FirstName", tbFirstName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@LastName", tbLastName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@BirthDate", tbBirthDate.Text));


            //command.Parameters.Add(new SqlParameter("@Birthdate" tbBirthDate));
//            command.Parameters.Add("@PersonID", SqlDbType.Int).Direction = ParameterDirection.Output;

            //command.Parameters.Add("@FirstName", SqlDbType.Int).Direction = ParameterDirection.Output;
            //command.Parameters.Add("@LastName", SqlDbType.Int).Direction = ParameterDirection.Output;
            //command.Parameters.Add("@Birthdate", SqlDbType.Int).Direction = ParameterDirection.Output;



            using (SqlDataReader rdr = command.ExecuteReader())
            {

                //SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                gvClients.DataSource = dt;
                gvClients.DataBind();


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            //Connection Object Closed
            conn.Close();
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> SearchFirstName(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["csLCCHP"].ConnectionString;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select FirstName from Person where " +
                "FirstName like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> names = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        names.Add(sdr["FirstName"].ToString());
                    }
                }
                conn.Close();
                return names;
            }
        }
    }

    
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> SearchLastName(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["csLCCHP"].ConnectionString;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select LastName from Person where " +
                "LastName like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> names = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        names.Add(sdr["LastName"].ToString());
                    }
                }
                conn.Close();
                return names;
            }
        }
 
    }
}