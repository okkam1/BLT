using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class EditClientInfo : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram2"].ConnectionString;

        Trace.Write("connectionString: " + connectionString);

        // if (tbBirthDate.Text=="")
        //   tbBirthDate.Text = DateTime.Today.ToShortDateString();

        futureDateValidator.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");

        NextButton.Visible = false;

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(connectionString);

            //            string com = "Select Lastname, FamilyID from dbo.Family order by Lastname asc";


            string com = @"Select f.FamilyID, p.PropertyID, f.Lastname, CONCAT(f.Lastname,' -- ', p.AddressLine1,' ',p.Zipcode ) NameAddress
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
            command.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = tbLastName.Text;
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
            command.Parameters.Add("@ClientID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            String sClientID = command.Parameters["@ClientID"].Value.ToString();

            String sReturnValue = command.Parameters["@ReturnValue"].Value.ToString();

            Trace.Write("sClientID: " + sClientID);

            if (sClientID != "" && sReturnValue == "0")
            {
                lbOutput.Text = "New Research Subject " + sClientID + " Inserted at: " + DateTime.Now;
                lbPopUp.Text = "New Research Subject " + sClientID + " Inserted at: " + DateTime.Now;
                NextButton.Visible = true;
                ModalPopupExtender1.Show();


                Session["FirstName"] = tbFirstName.Text;
                Session["LastName"] = FamilyNameList.SelectedItem.ToString();
                Session["ClientID"] = sClientID;

            }
            else if (sReturnValue == "50000")
            {
                lbOutput.Text = "Possible Duplicate Client based on Name and birthdate";
                lbPopUp.Text = "Possible Duplicate Client based on Name and birthdate";

                ModalPopupExtender1.Show();
            }
            else
            {
                lbOutput.Text = "Failed to Insert New Client";
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

    }

    protected void getFamilyMembers(String sFamilyIDIn)
    {

        SqlConnection con = new SqlConnection(connectionString);

        string com = "select PersonID,FirstName,MiddleName from person where PersonID in (select PersonID from persontoFamily where FamilyID = '" + sFamilyIDIn + "')";


        SqlDataAdapter adpt = new SqlDataAdapter(com, con);

        DataTable dt = new DataTable();

        adpt.Fill(dt);

        ddlFamilyMembers.DataSource = dt;
                                                                                                                                      
        ddlFamilyMembers.DataBind();

        ddlFamilyMembers.DataTextField = "FirstName";
        ddlFamilyMembers.DataValueField = "PersonID";

        ddlFamilyMembers.DataBind();


        Trace.Write("connectionString: " + connectionString);

        //if (dt.Rows.Count>1)
        if (ddlFamilyMembers.Items.Count > 1)
        {
            pnlFamilyMembers.Visible = true;
        }
        else
        {
            pnlFamilyMembers.Visible = false;
            getIndividual(ddlFamilyMembers.SelectedValue.ToString());
        }


    }
    
    protected void FamilyNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        getFamilyMembers(FamilyNameList.SelectedValue);
    }

    protected void getIndividual(String sPersonIDIn)
    {

        SqlConnection con = new SqlConnection(connectionString);

        string com = "select *, (select languageID from PersontoLanguage ptl where p.personid = ptl.personid) as LanguageID from person p where p.personid  = '" + sPersonIDIn + "'";


        SqlDataAdapter adpt = new SqlDataAdapter(com, con);

        DataTable dt = new DataTable();

        adpt.Fill(dt);

        //fill UI screen with pre-selected values
        if (dt.Rows.Count > 0)
        {

            tbFirstName.Text = dt.Rows[0]["FirstName"].ToString();

            tbLastName.Text = dt.Rows[0]["LastName"].ToString();
            tbMiddleName.Text = dt.Rows[0]["MiddleName"].ToString();
            tbBirthDate.Text = dt.Rows[0]["BirthDate"].ToString();
            if (dt.Rows[0]["Gender"].ToString().ToLower() == "f")
                rblGender.SelectedValue = "F";
            if (dt.Rows[0]["Gender"].ToString().ToLower() == "m")
                rblGender.SelectedValue = "M";
            
           // if (dt.Rows[0]["LanguageID"].ToString() != null)
           //     ddlLanguage.SelectedIndex = Convert.ToInt32( dt.Rows[0]["LanguageID"].ToString() );
         
          //  rblMoved.SelectedIndex = Convert.ToInt16(dt.Rows[0]["Moved"].ToString() );
            tbFirstName.Text = dt.Rows[0]["FirstName"].ToString();

        }

        Trace.Write("connectionString: " + connectionString);
        
    }

    
    protected void ddlFamilyMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get indivifual
        getIndividual(ddlFamilyMembers.SelectedValue.ToString());
    }
}