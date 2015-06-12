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
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

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

            cvFutureSampleDate.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
            cvFutureLabDate.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");

            Trace.Write("connectionString: " + connectionString);

            SqlConnection conLang = new SqlConnection(connectionString);

            string comLang = "Select LabID, Upper(LabName) as LabName from dbo.Lab order by LabName asc";
            SqlDataAdapter adptLang = new SqlDataAdapter(comLang, conLang);

            DataTable dtLab = new DataTable();

            adptLang.Fill(dtLab);

            ddlLab.DataSource = dtLab; 

            ddlLab.DataBind();

            ddlLab.DataTextField = "LabName";
            ddlLab.DataValueField = "LabID";

            ddlLab.DataBind();
            // if (!Page.IsPostBack)
            ddlLab.Items.Insert(0, "-");


            //child status code

            string comChildStatusTypeQuery = "EXEC [dbo].[usp_SlChildStatus]";

            SqlDataAdapter adptChildStatusType = new SqlDataAdapter(comChildStatusTypeQuery, conLang);

            DataTable dtChildStatusType = new DataTable();

            adptChildStatusType.Fill(dtChildStatusType);

            ddlClientStatusCode.DataSource = dtChildStatusType;

            ddlClientStatusCode.DataBind();

             ddlClientStatusCode.DataTextField = "StatusName";
             ddlClientStatusCode.DataValueField = "StatusID";

             ddlClientStatusCode.DataBind();
            // if (!Page.IsPostBack)
             ddlClientStatusCode.Items.Insert(0, "-");


            //Test Type

            //string comTestType = "Select LabID, Upper(LabName) as LabName from dbo.Lab order by LabName asc";
            string comTestType = "EXEC usp_slTargetSampleType 'person'";
            SqlDataAdapter adptTestType = new SqlDataAdapter(comTestType, conLang);

            DataTable dtTestType = new DataTable();

            adptTestType.Fill(dtTestType);

            ddlTestType.DataSource = dtTestType;

            ddlTestType.DataBind();

             ddlTestType.DataTextField = "SampleTypeName";
             ddlTestType.DataValueField = "SampleTypeID";

             ddlTestType.DataBind();
            // if (!Page.IsPostBack)
             ddlTestType.Items.Insert(0, "-");

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
                command.Parameters.Add("@Blood_Lead_Result", SqlDbType.Decimal).Value = Convert.ToDecimal(tbBloodLeadResult.Text);
            if (ddlTestType.Text != "")
                command.Parameters.Add("@Test_Type", SqlDbType.Int).Value = Convert.ToInt32(ddlTestType.Text);
            if (ddlLab.Text != "")
                command.Parameters.Add("@Lab_ID", SqlDbType.Int).Value = Convert.ToInt32(ddlLab.Text);
            if (ddlClientStatusCode.SelectedValue != "-")
                command.Parameters.Add("@Child_Status_Code", SqlDbType.Int).Value = Convert.ToInt32(ddlClientStatusCode.SelectedValue);
            if (tbHemoglobin.Text != "")
                command.Parameters.Add("@Hemoglobin_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(tbHemoglobin.Text);


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
                lbOutput.Text = "Failed to Insert New Blood Test Results";
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