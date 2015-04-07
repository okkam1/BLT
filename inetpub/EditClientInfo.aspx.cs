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

        //NextButton.Visible = false;

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
            SqlCommand command = new SqlCommand("usp_upClientWebScreen", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Family_ID", SqlDbType.Int).Value = FamilyNameList.SelectedValue;
            command.Parameters.Add("@Person_ID", SqlDbType.Int).Value = ddlFamilyMembers.SelectedValue;
            command.Parameters.Add("@New_FirstName", SqlDbType.VarChar).Value = tbFirstName.Text;
            command.Parameters.Add("@New_MiddleName", SqlDbType.VarChar).Value = tbMiddleName.Text;
            command.Parameters.Add("@New_LastName", SqlDbType.VarChar).Value = tbLastName.Text;
            command.Parameters.Add("@New_BirthDate", SqlDbType.DateTime).Value = tbBirthDate.Text;
            command.Parameters.Add("@New_Gender", SqlDbType.Char).Value = rblGender.SelectedValue;
            command.Parameters.Add("@New_LanguageID", SqlDbType.TinyInt).Value = ddlLanguage.SelectedValue;
            command.Parameters.Add("@New_EthnicityID", SqlDbType.TinyInt).Value = ddlEthnicity.SelectedValue;

            if (rblMoved.SelectedValue != "" && rblMoved.SelectedValue != null)
                command.Parameters.Add("@New_Moved", SqlDbType.Bit).Value = Convert.ToByte(rblMoved.SelectedValue);

            if (rblTravel.SelectedValue != "" && rblTravel.SelectedValue != null)
                command.Parameters.Add("@New_ForeignTravel", SqlDbType.Bit).Value = Convert.ToByte(rblTravel.SelectedValue);

            if (tbClientNotes.Text != "")
                command.Parameters.Add("@New_Notes", SqlDbType.VarChar).Value = tbClientNotes.Text;

            if (rblOutOfSite.SelectedValue != "" && rblOutOfSite.SelectedValue!=null)
                command.Parameters.Add("@New_OutofSite", SqlDbType.Bit).Value = Convert.ToByte(rblOutOfSite.SelectedValue);
            
            //command.Parameters.Add("@Hobby_ID", SqlDbType.SmallInt).Value = rblGender.Text;
            //command.Parameters.Add("@Hobby_Notes", SqlDbType.VarChar).Value = tbHobbyNotes.Text;
            //command.Parameters.Add("@Child_Notes", SqlDbType.VarChar).Value = tbChildNotes.Text;
            //command.Parameters.Add("@Release_Notes", SqlDbType.VarChar).Value = rblGender.Text;
           
            //command.Parameters.Add("@ClientID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion
            //****No output param???

            command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            String sClientID = ""; //command.Parameters["@ClientID"].Value.ToString();

            String sReturnValue = command.Parameters["@ReturnValue"].Value.ToString();

            Trace.Write("sClientID: " + sClientID);

            if (sReturnValue == "0")
            {
                lbOutput.Text = "Research Subject " + sClientID + " Updated at: " + DateTime.Now;
                lbPopUp.Text = "Research Subject " + sClientID + " Updated at: " + DateTime.Now;
                //NextButton.Visible = true;
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
                lbOutput.Text = "Failed to Update Client";
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

    protected void getFamilyMembers(String sFamilyIDIn)
    {

        resetFields();

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
        ddlFamilyMembers.Items.Insert(0, "-");


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
        resetFields();
        pnlFamilyMembers.Visible = false;
        getFamilyMembers(FamilyNameList.SelectedValue);
    }

    protected void resetFields()
    {
        tbFirstName.Text = "";
        tbLastName.Text = "";
        tbMiddleName.Text = "";
        tbBirthDate.Text = "";
        rblGender.ClearSelection();
        ddlLanguage.SelectedIndex = 0;
        ddlEthnicity.SelectedIndex = 0;

        rblMoved.ClearSelection();
        rblTravel.ClearSelection();

        //tbTravelNotes.Text = "";
        tbClientNotes.Text = "";

        rblOutOfSite.ClearSelection();
       // rblHobby.ClearSelection();

       // tbHobbyNotes.Text = "";

        
    }

    protected void getIndividual(String sPersonIDIn)
    {
        
        resetFields();

        SqlConnection con = new SqlConnection(connectionString);

        string com = @"select *,
(select top 1 LanguageID from PersontoLanguage ptl where p.personid = ptl.personid order by CreatedDate DESC) as LanguageID,
(select top 1 EthnicityID from PersontoEthnicity pte where p.personid = pte.personid  order by CreatedDate DESC) as EthnicityID,
CAST (OutofSite as varchar) as OutofSiteV,
CAST (CONVERT(VARCHAR(10),BirthDate,101) as varchar) as BirthDateV,
CAST (ForeignTravel as varchar) as travelV
from person p
where p.personid  = '" + sPersonIDIn + "'";


        SqlDataAdapter adpt = new SqlDataAdapter(com, con);

        DataTable dt = new DataTable();

        adpt.Fill(dt);

        //fill UI screen with pre-selected values
        if (dt.Rows.Count > 0)
        {

            tbFirstName.Text = dt.Rows[0]["FirstName"].ToString();

            tbLastName.Text = dt.Rows[0]["LastName"].ToString();
            tbMiddleName.Text = dt.Rows[0]["MiddleName"].ToString();
            tbBirthDate.Text = dt.Rows[0]["BirthDateV"].ToString();
            if (dt.Rows[0]["Gender"].ToString().ToLower() == "f")
                rblGender.SelectedValue = "F";
            if (dt.Rows[0]["Gender"].ToString().ToLower() == "m")
                rblGender.SelectedValue = "M";

            if ((dt.Rows[0]["LanguageID"].ToString() != null) && (ddlLanguage.Items.FindByValue(dt.Rows[0]["LanguageID"].ToString().Trim()) != null))
            {
                ddlLanguage.SelectedValue = dt.Rows[0]["LanguageID"].ToString().Trim();
            }
            else
            {
                ddlLanguage.SelectedIndex = 0;
            }



            if ((dt.Rows[0]["EthnicityID"].ToString() != null) && (ddlEthnicity.Items.FindByValue(dt.Rows[0]["EthnicityID"].ToString().Trim()) != null))
            {
                ddlEthnicity.SelectedValue = dt.Rows[0]["EthnicityID"].ToString().Trim();
            }
            else
            {
                ddlEthnicity.SelectedIndex = 0;
            }

            //lbOutput.Text = dt.Rows[0]["LanguageID"].ToString();

            Trace.Write("LanguageID: " + dt.Rows[0]["LanguageID"].ToString());
            Trace.Write("EthnicityID: " + dt.Rows[0]["EthnicityID"].ToString() );

            if (dt.Rows[0]["Moved"].ToString().ToLower() == "true")
                rblMoved.SelectedValue = "1";

            if (dt.Rows[0]["Moved"].ToString().ToLower() == "false")
                rblMoved.SelectedValue = "0";

            rblTravel.SelectedValue = dt.Rows[0]["travelV"].ToString();

            rblOutOfSite.SelectedValue = dt.Rows[0]["OutofSiteV"].ToString();

            //rblTravelNew.SelectedValue = dt.Rows[0]["ForeignTravel"].ToString();

          //  tbTravelNotes.Text = dt.Rows[0]["TravelNotes"].ToString();

            Trace.Write("foreign travel: " + dt.Rows[0]["Moved"].ToString() );// rblTravel.Items.FindByValue(dt.Rows[0]["ForeignTravel"].ToString()).ToString();

            Trace.Write("Moved: " + dt.Rows[0]["Moved"].ToString()) ;

            Trace.Write("Client ID: "+dt.Rows[0]["PersonID"].ToString() );
            //ddlLanguage.SelectedIndex = 3;
         
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