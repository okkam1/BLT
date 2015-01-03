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
        //string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram2"].ConnectionString;

        Trace.Write("connectionString: " + connectionString);

        if (tbBirthDate.Text=="")
            tbBirthDate.Text = DateTime.Today.ToShortDateString();

        NextButton.Visible = false;

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(connectionString);

//            string com = "Select Lastname, FamilyID from dbo.Family order by Lastname asc";


            string com = @"Select f.FamilyID, p.PropertyID, f.Lastname, CONCAT(f.Lastname,' -- ', p.StreetNumber,' ',p.Street,' ',p.Zipcode ) NameAddress
from dbo.Family f 
     join Property p 
       on p.PropertyID = f.PrimaryPropertyID
order by f.Lastname
";


            SqlDataAdapter adpt = new SqlDataAdapter(com, con);

            DataTable dt = new DataTable();

            adpt.Fill(dt);

            FamilyNameList.DataSource = dt;

            FamilyNameList.DataBind();

            Random r1 = new Random();

            int addr = r1.Next(9999);
            int zip = r1.Next(99999);

            FamilyNameList.DataTextField = "NameAddress";
            FamilyNameList.DataValueField = "FamilyID";

            FamilyNameList.DataBind();
            //FamilyNameList.("test");
            // if (!Page.IsPostBack)
            FamilyNameList.Items.Insert(0, "(Family name -- PRIMARY residence)");
            // FamilyNameList.Items.Insert(1, "Bonifacic"  + " -- " + addr.ToString() + " Main St, " + zip.ToString());

            Trace.Write("connectionString: " + connectionString);

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
        }

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
            //command.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = FamilyNameList.SelectedItem.ToString();
            command.Parameters.Add("@Birth_Date", SqlDbType.DateTime).Value = tbBirthDate.Text;
            command.Parameters.Add("@Gender_", SqlDbType.Char).Value = rblGender.SelectedValue;
            command.Parameters.Add("@Language_ID", SqlDbType.TinyInt).Value = ddlLanguage.SelectedValue;
            command.Parameters.Add("@Moved_", SqlDbType.Bit).Value = Convert.ToByte(rblMoved.SelectedValue);
            command.Parameters.Add("@Travel", SqlDbType.Bit).Value = Convert.ToByte(rblTravel.SelectedValue);
            command.Parameters.Add("@Travel_Notes", SqlDbType.VarChar).Value = tbTravelNotes.Text;
            command.Parameters.Add("@Out_of_Site", SqlDbType.Bit).Value = Convert.ToByte(rblOutOfSite.SelectedValue);
            //command.Parameters.Add("@Hobby_ID", SqlDbType.SmallInt).Value = rblGender.Text;
            command.Parameters.Add("@Hobby_Notes", SqlDbType.VarChar).Value = tbHobbyNotes.Text;
            command.Parameters.Add("@Child_Notes", SqlDbType.VarChar).Value = tbChildNotes.Text;
            command.Parameters.Add("@Release_Notes", SqlDbType.VarChar).Value = rblGender.Text;
            command.Parameters.Add("@is_Smoker", SqlDbType.Bit).Value = Convert.ToByte(rblSmoker.SelectedValue);
            command.Parameters.Add("@ClientID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            String sClientID = command.Parameters["@ClientID"].Value.ToString();

            Trace.Write("sClientID: " +sClientID);
            
            if (sClientID != "")
            {
                lbOutput.Text = "New Research Subject " + sClientID+" Inserted at: " + DateTime.Now;
                lbPopUp.Text = "New Research Subject " + sClientID + " Inserted at: " + DateTime.Now;
                NextButton.Visible = true;
                ModalPopupExtender1.Show();

                Session["FirstName"] = tbFirstName.Text;
                Session["LastName"] = FamilyNameList.SelectedItem.ToString();
                Session["ClientID"] = sClientID;

            }
            else
            {
                lbOutput.Text = "Failed to Insert New Researh Subject";
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
}