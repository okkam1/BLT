using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddChild : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        Trace.Write("connectionString: " + connectionString);

        futureDateValidator.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");

        NextButton.Visible = false;

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(connectionString);

            GetFamilies();
            
            Trace.Write("connectionString: " + connectionString);

            //fill language drop down
            SqlConnection conLang = new SqlConnection(connectionString);

            string comLang = "Select LanguageID, Upper(LanguageName) as LanguageName from dbo.Language order by LanguageName asc";

            SqlDataAdapter adptLang = new SqlDataAdapter(comLang, conLang);

            DataTable dtLang = new DataTable();

            adptLang.Fill(dtLang);

            ddlLanguage.DataSource = dtLang;

            ddlLanguage.DataBind();

            ddlLanguage.DataTextField = "LanguageName";
            ddlLanguage.DataValueField = "LanguageID";

            ddlLanguage.DataBind();
            // if (!Page.IsPostBack)
            ddlLanguage.Items.Insert(0, "-");

            //fill Ethnicity Drop down

            SqlConnection conEthnicity = new SqlConnection(connectionString);

            string comEthnicity = "Select EthnicityID, Upper(Ethnicity) as Ethnicity, HistoricEthnicityCode from dbo.Ethnicity order by Ethnicity asc";

            SqlDataAdapter adptEthnicity = new SqlDataAdapter(comEthnicity, conEthnicity);

            DataTable dtEthnicity = new DataTable();

            adptEthnicity.Fill(dtEthnicity);

            ddlEthnicity.DataSource = dtEthnicity;

            ddlEthnicity.DataBind();

           ddlEthnicity.DataTextField = "Ethnicity";
           ddlEthnicity.DataValueField = "EthnicityID";

            ddlEthnicity.DataBind();
            ddlEthnicity.Items.Insert(0, "-");

        }

        //choose new family by default if one was added
        string LastName = (string)(Session["LastName"]);
        string FamilyID = (string)(Session["FamilyID"]);

        Trace.Write("FamilyID: " + FamilyID);

        if (FamilyID != "" && FamilyID!=null)
            FamilyNameList.SelectedValue = FamilyID;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            lbOutput.Text = "";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_InsertNewClientWebScreen", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Family_ID", SqlDbType.Int).Value = FamilyNameList.SelectedValue;
            command.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = tbFirstName.Text;
            command.Parameters.Add("@Middle_Name", SqlDbType.VarChar).Value = tbMiddleName.Text;
            if (tbLastName.Text != "")
                command.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = tbLastName.Text;
            command.Parameters.Add("@Birth_Date", SqlDbType.DateTime).Value = tbBirthDate.Text;
            command.Parameters.Add("@Gender_", SqlDbType.Char).Value = rblGender.SelectedValue;
            command.Parameters.Add("@is_Client", SqlDbType.Bit).Value = Convert.ToByte(rblClient.SelectedValue); 
            command.Parameters.Add("@Language_ID", SqlDbType.TinyInt).Value = ddlLanguage.SelectedValue;
            command.Parameters.Add("@Ethnicity_ID", SqlDbType.TinyInt).Value = ddlEthnicity.SelectedValue;
           // command.Parameters.Add("@Moved_", SqlDbType.Bit).Value = Convert.ToByte(rblMoved.SelectedValue);
            command.Parameters.Add("@Travel", SqlDbType.Bit).Value = Convert.ToByte(rblTravel.SelectedValue);
           // command.Parameters.Add("@Travel_Notes", SqlDbType.VarChar).Value = tbTravelNotes.Text;
            command.Parameters.Add("@Out_of_Site", SqlDbType.Bit).Value = Convert.ToByte(rblOutOfSite.SelectedValue);
            
           // command.Parameters.Add("@Release_Notes", SqlDbType.VarChar).Value = tbReleaseNotes.Text;
            command.Parameters.Add("@Client_Notes", SqlDbType.VarChar).Value = tbClientNotes.Text;
            
            command.Parameters.Add("@ClientID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue; 

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            String sClientID = command.Parameters["@ClientID"].Value.ToString();

            String sReturnValue = command.Parameters["@ReturnValue"].Value.ToString();

            Trace.Write("sClientID: " +sClientID);
            
            if (sClientID != "" && sReturnValue=="0")
            {
                lbOutput.Text = "New Research Subject " + sClientID+" Inserted at: " + DateTime.Now;
                lbPopUp.Text = "New Research Subject " + sClientID + " Inserted at: " + DateTime.Now;
                NextButton.Visible = true;
                ModalPopupExtender1.Show();


                Session["FirstName"] = tbFirstName.Text;
                Session["LastName"] = FamilyNameList.SelectedItem.ToString();
                Session["ClientID"] = sClientID;

            }
            else if (sReturnValue=="50000") 
            {
                lbOutput.Text = "Possible Duplicate Client based on Name and birthdate";
                lbPopUp.Text = "Possible Duplicate Client based on Name and birthdate";

                ModalPopupExtender1.Show();
            }
            else
            {
                lbOutput.Text = "Failed to Insert New Client (FamilyID: " + FamilyNameList.DataValueField;
                lbPopUp.Text = lbOutput.Text;
                ModalPopupExtender1.Show();
            }

            
        }
        catch (SqlException exSQL)
        {
            
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() +  " " + DateTime.Now;
            
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
        Response.Redirect("Questionnaire.aspx");
    }

    protected void AddAnotherButton_Click(object sender, EventArgs e)
    {
        tbFirstName.Text = "";
        tbMiddleName.Text = "";
        rblGender.ClearSelection();
        tbBirthDate.Text = "";
    }

    protected void GetFamilies()
    {
        try
        {

            SqlConnection sqlConnection_family = new SqlConnection(connectionString);

            SqlCommand command_family = new SqlCommand("usp_SlFamilyNametoProperty", sqlConnection_family);
            command_family.CommandType = CommandType.StoredProcedure;

            sqlConnection_family.Open();
            command_family.ExecuteNonQuery();
            sqlConnection_family.Close();

            using (SqlDataAdapter da_family = new SqlDataAdapter(command_family))
            {
                DataTable dt_family = new DataTable();
                da_family.Fill(dt_family);
                FamilyNameList.DataSource = dt_family;

                FamilyNameList.DataTextField = "FamilyProperty";
                FamilyNameList.DataValueField = "FamilyID";
                FamilyNameList.DataBind();

                ListItem itemHyphen = new ListItem();
                itemHyphen.Text = "-";
                itemHyphen.Value = "-";

                FamilyNameList.Items.Insert(0, "-");

            }
        }
        catch (SqlException exSQL)
        {
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() + " " + DateTime.Now;
            AddAnother.Visible = false;
            lbPopUp.Text = lbOutput.Text;
            ModalPopupExtender1.Show();

            Trace.Write("SQL Error" + exSQL.Message.ToString());

        }
        catch (Exception ex)
        {
            lbOutput.Text = "ERROR: " + ex.Message.ToString() + " " + DateTime.Now;
            AddAnother.Visible = false;
            lbPopUp.Text = lbOutput.Text;
            ModalPopupExtender1.Show();

            Trace.Write("Error" + ex.Message.ToString());
        }

    }
}