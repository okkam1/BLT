using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddLanguage : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram-Liam"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram2"].ConnectionString;

        Trace.Write("connectionString: " + connectionString);

        if (!IsPostBack) //check if the webpage is loaded for the first time.
        {
            ViewState["PreviousPage"] =
        Request.UrlReferrer;//Saves the Previous page url in ViewState
        }

    }

    protected void Insert_Click(object sender, EventArgs e)
    {
        try
        {

            lbOutput.Text = "";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("[usp_InsertLanguage]", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LanguageName", SqlDbType.VarChar).Value = Language.Text;
            command.Parameters.Add("@LanguageID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            lbOutput.Text = "New Language: " +Language.Text + " Inserted at: " + DateTime.Now;

        }
        catch (SqlException exSQL)
        {
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() + DateTime.Now;
            Trace.Write("SQL Error" + exSQL.Message.ToString());

        }
        catch (Exception ex)
        {
            lbOutput.Text = "ERROR: " + ex.Message.ToString() + DateTime.Now;
            Trace.Write("Error" + ex.Message.ToString());
        }

    }
    protected void Back_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
        //contains Previous page URL
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
            //Previous page by retrieving the PreviousPage Url from ViewState.
        }
    }
}