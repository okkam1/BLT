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
}