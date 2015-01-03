using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class BloodTestResults : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram-Liam"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram2"].ConnectionString;

        Trace.Write("connectionString: " + connectionString);

        SqlConnection con = new SqlConnection(connectionString);

        if (!Page.IsPostBack)
        {
            string FirstName = (string)(Session["FirstName"]);
            string LastName = (string)(Session["LastName"]);
            string ClientID = (string)(Session["ClientID"]);

            lblHeader.Text += "for " + FirstName + " " + LastName + " (" + ClientID + ") ";


        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            lbOutput.Text = "";

            string FirstName = (string)(Session["FirstName"]);
            string LastName = (string)(Session["LastName"]);
            string ClientID = (string)(Session["ClientID"]);

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_InsertNewBloodLeadTestResultsWebScreen", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Person_ID", SqlDbType.Int).Value = Convert.ToInt32(ClientID);
            if (tbSampleDate.Text!="")
                command.Parameters.Add("@Sample_Date", SqlDbType.DateTime).Value = tbSampleDate.Text;
            if (tbLabDate.Text != "")
                command.Parameters.Add("@Lab_Date", SqlDbType.DateTime).Value = tbLabDate.Text;
            if (tbBloodLeadResult.Text != "")
                command.Parameters.Add("@Blood_Lead_Result", SqlDbType.Int).Value = Convert.ToInt32(tbBloodLeadResult.Text);
            if (tbTestType.Text != "")
                command.Parameters.Add("@Test_Type", SqlDbType.Int).Value = Convert.ToInt32(tbTestType.Text);
            if (tbLab.Text != "")
                command.Parameters.Add("@Lab", SqlDbType.VarChar).Value = tbLab.Text;
            if (tbLabID.Text != "")
                command.Parameters.Add("@Lab_ID", SqlDbType.Int).Value = Convert.ToInt32(tbLabID.Text);
            if (tbChildStatusCode.Text != "")
                command.Parameters.Add("@Child_Status_Code", SqlDbType.Int).Value = Convert.ToInt32(tbChildStatusCode.Text);
            if (tbHemoglobin.Text != "")
                command.Parameters.Add("@Hemoglobin_Value", SqlDbType.Int).Value = Convert.ToInt32(tbHemoglobin.Text);


            command.Parameters.Add("@Blood_Test_Results_ID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            String returnValue = command.Parameters["@Blood_Test_Results_ID"].Value.ToString();

            Trace.Write("returnValue: " + returnValue);

            if (returnValue != "")
            {
                lbOutput.Text = "New Blood Test Results Data " + returnValue + " Inserted at: " + DateTime.Now;

                lbPopUp.Text = lbOutput.Text;

                NextButton.Visible = true;
                ModalPopupExtender1.Show();
            }
            else
            {
                lbOutput.Text = "Failed to Insert New Questionnaire";
                lbPopUp.Text = lbOutput.Text;
                ModalPopupExtender1.Show();
            }


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

    

    protected void NextButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("/");
    }
}