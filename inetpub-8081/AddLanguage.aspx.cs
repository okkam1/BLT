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
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

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
            command.Parameters.Add("@LanguageName", SqlDbType.VarChar).Value = Language.Text.ToUpper();
            command.Parameters.Add("@LanguageID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            sqlConnection.Open();

            int rownum = 0;

                rownum = command.ExecuteNonQuery();

                String sID = command.Parameters["@LanguageID"].Value.ToString();

                Trace.Write("sID: " + sID);

                if (sID != "")
                {
                    lbOutput.Text = "New Language #" + sID + " Inserted at: " + DateTime.Now;
                    lbPopUp.Text = lbOutput.Text;

                    NextButton.Visible = true;
                    ModalPopupExtender1.Show();
                }
                else
                {
                    lbOutput.Text = "Failed to Insert New Language";
                    lbPopUp.Text = lbOutput.Text;
                    ModalPopupExtender1.Show();
                }

            sqlConnection.Close();


        }
        catch (SqlException exSQL)
        {
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() + " " + DateTime.Now;

            lbPopUp.Text = lbOutput.Text;
            ModalPopupExtender1.Show();

            Trace.Write("SQL Error" + exSQL.Message.ToString());

        }
        catch (Exception ex)
        {
            lbOutput.Text = "ERROR: " + ex.Message.ToString() + " " + DateTime.Now;

            lbPopUp.Text = lbOutput.Text;
            ModalPopupExtender1.Show();

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