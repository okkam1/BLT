
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

public partial class EditFamily : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    string sCurrentFamilyName = "";
    string sCurrentFamilyID = "";
    bool bIsNewAddress = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        //updateLanguage();

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

            //sCurrentFamilyName = dt.Rows[0]["Lastname"].ToString();
            //sCurrentFamilyID = dt.Rows[0]["FamilyID"].ToString();

            //Trace.Write("sCurrentFamilyName: " + sCurrentFamilyName);
            //Trace.Write("sCurrentFamilyID: " + sCurrentFamilyID);

            FamilyNameList.DataSource = dt;

            FamilyNameList.DataBind();

            Random r1 = new Random();

            FamilyNameList.DataTextField = "NameAddress";
            FamilyNameList.DataValueField = "FamilyID";

            FamilyNameList.DataBind();
            FamilyNameList.Items.Insert(0, "(Family name -- PRIMARY residence)");

            Trace.Write("connectionString: " + connectionString);

        }


    }

    protected void updateLanguage()
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram2"].ConnectionString;

        Trace.Write("connectionString: " + connectionString);

        SqlConnection con = new SqlConnection(connectionString);

        string com = "Select LanguageID,LanguageName from dbo.Language order by LanguageName asc";

        SqlDataAdapter adpt = new SqlDataAdapter(com, con);

        DataTable dt = new DataTable();

        adpt.Fill(dt);

        //ddlLanguage.DataSource = dt;

        //ddlLanguage.DataBind();

        //ddlLanguage.DataTextField = "LanguageName";

        //ddlLanguage.DataValueField = "LanguageID";
        //ddlLanguage.DataBind();
        //ddlLanguage.Items.Insert(0, "-");

    }

    protected void RefreshLanguage_Click(object sender, EventArgs e)
    {
        updateLanguage();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            lbOutput.Text = "";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_upFamilyWebScreen", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@New_Last_Name", SqlDbType.VarChar).Value = tbLastName.Text;
            command.Parameters.Add("@New_Address_Line1", SqlDbType.VarChar).Value = tbAddress.Text; // +" " + DropDownListStreetSuffix.Text;
            command.Parameters.Add("@New_Address_Line2", SqlDbType.VarChar).Value = tbAddressLine2.Text;
            command.Parameters.Add("@New_CityName", SqlDbType.VarChar).Value = tbCity.Text;

            command.Parameters.Add("@New_StateAbbr", SqlDbType.VarChar).Value = ddlState.SelectedValue;
            command.Parameters.Add("@New_ZipCode", SqlDbType.VarChar).Value = tbZip.Text;
            if (tbHomePhone.Text != "")
                command.Parameters.Add("@New_HomePhone", SqlDbType.BigInt).Value = Convert.ToInt64(tbHomePhone.Text);
            if (tbWorkPhone.Text != "")
                command.Parameters.Add("@New_WorkPhone", SqlDbType.BigInt).Value = Convert.ToInt64(tbWorkPhone.Text);
            command.Parameters.Add("@New_Pets", SqlDbType.Bit).Value = Convert.ToInt16(ddlPets.SelectedValue);

            command.Parameters.Add("@New_Number_of_Smokers", SqlDbType.Bit).Value = Convert.ToInt16(ddlSmokers.SelectedValue);

            command.Parameters.Add("@New_Pets_in_and_out", SqlDbType.Bit).Value = Convert.ToInt16(RadioButtonListPetsInOut.SelectedValue);

            if (tbFamilyNotes.Text != "")
                command.Parameters.Add("@New_Family_Notes", SqlDbType.VarChar).Value = tbFamilyNotes.Text;

            command.Parameters.Add("@isNewAddress", SqlDbType.Bit).Value = Convert.ToInt16(bIsNewAddress);

            command.Parameters.Add("@DEBUG", SqlDbType.Bit).Value = 1;

            //command.Parameters.Add("@Family_ID", SqlDbType.Bit).Value = Convert.ToInt16(FamilyNameList.SelectedValue);

           //command.Parameters.Add("@Family_ID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sqlConnection.Open();

            int rownum = 0;

            try
            {
                rownum = command.ExecuteNonQuery();

                String sID = "123"; // command.Parameters["@Family_ID"].Value.ToString();

                String sReturnValue = command.Parameters["@ReturnValue"].Value.ToString();

                Trace.Write("sID: " + sID);

                Trace.Write("sReturnValue: " + sReturnValue);

                if (sID != "" && sReturnValue == "0")
                {
                    lbOutput.Text = "Existing Family #" + sID + " Updated at: " + DateTime.Now;
                    lbPopUp.Text = lbOutput.Text;

                    //NextButton.Visible = true;
                    ModalPopupExtender1.Show();
                }
                else if (sReturnValue == "50000")
                {
                    lbOutput.Text = "Possible Duplicate Family based on Last Name, Street Number, Street Name, City, State, and Zip Code";
                    lbPopUp.Text = "Possible Duplicate Family based on Last Name, Street Number, Street Name, City, State, and Zip Code";

                    ModalPopupExtender1.Show();
                }

                else if (sReturnValue == "50001") // || sReturnValue=="50002")
                {
                    lbOutput.Text = "Please provide Family_ID.";
                    lbPopUp.Text = "Please provide Family_ID.";

                    ModalPopupExtender1.Show();
                }

                else
                {
                    lbOutput.Text = "Failed to Update Family";
                    lbPopUp.Text = lbOutput.Text;
                    ModalPopupExtender1.Show();
                }

            }

            catch (Exception error)
            {
                sqlConnection.Close();
                throw new Exception("Exception caught in AddFamily", error);

            }

            sqlConnection.Close();


        }
        catch (SqlException exSQL)
        {
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() + " " + DateTime.Now;
            Trace.Write("SQL Error" + exSQL.Message.ToString());

        }
        catch (Exception ex)
        {
            lbOutput.Text = "ERROR: " + ex.Message.ToString() + " " + DateTime.Now;
            Trace.Write("Error" + ex.Message.ToString());
        }

    }
    
    protected void ddlPets_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPets.SelectedIndex != 0)
        {
            RadioButtonListPetsInOut.Enabled = true;
        }
        else
        {
            RadioButtonListPetsInOut.SelectedIndex = 1;
            RadioButtonListPetsInOut.Enabled = false;
        }
    }

    protected void FamilyNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetFields();

        disableAddress();
        
        pnlEditAddress.Visible = false;

        btnUpdate.Visible = false;

        getFamilyDetails(FamilyNameList.SelectedValue.ToString());

        //tbLastName.Text = sCurrentFamilyName;
        Trace.Write("sCurrentFamilyName: " + sCurrentFamilyName);
    }

    protected void resetFields()
    {
        tbLastName.Text = "";


    }


    protected void getFamilyDetails(String sFamilyIDIn)
    {

        //resetFields();

        SqlConnection con = new SqlConnection(connectionString);

        string com = @"exec usp_SLEditFamilyWebScreenInformation @Family_ID='" + sFamilyIDIn + "'";


        SqlDataAdapter adpt = new SqlDataAdapter(com, con);

        DataTable dt = new DataTable();

        adpt.Fill(dt);

        //fill UI screen with pre-selected values
        if (dt.Rows.Count > 0)
        {

            pnlEditAddress.Visible = true;

            btnUpdate.Visible = true;

            tbLastName.Text = dt.Rows[0]["LastName"].ToString();
            tbAddress.Text = dt.Rows[0]["AddressLine1"].ToString();
            tbAddressLine2.Text = dt.Rows[0]["AddressLine2"].ToString();
            tbCity.Text = dt.Rows[0]["city"].ToString();

            if ((dt.Rows[0]["State"].ToString() != null) && (ddlState.Items.FindByValue(dt.Rows[0]["State"].ToString().Trim()) != null))
            {
                ddlState.SelectedValue = dt.Rows[0]["State"].ToString().Trim();
            }
            else
            {
                ddlState.SelectedIndex = 0;
            }


            tbZip.Text = dt.Rows[0]["zipCode"].ToString();

            tbHomePhone.Text = dt.Rows[0]["HomePhoneNumber"].ToString();
            tbWorkPhone.Text = dt.Rows[0]["WorkPhoneNumber"].ToString();

            if ((dt.Rows[0]["NumberofSmokers"].ToString() != null) && (ddlSmokers.Items.FindByValue(dt.Rows[0]["NumberofSmokers"].ToString().Trim()) != null))
            {
                ddlSmokers.SelectedValue = dt.Rows[0]["NumberofSmokers"].ToString().Trim();
            }
            else
            {
                ddlSmokers.SelectedIndex = 0;
            }

            if ((dt.Rows[0]["Pets"].ToString() != null) && (ddlPets.Items.FindByValue(dt.Rows[0]["Pets"].ToString().Trim()) != null))
            {
                ddlPets.SelectedValue = dt.Rows[0]["Pets"].ToString().Trim();
            }
            else
            {
                ddlPets.SelectedIndex = 0;
            }

            //RadioButtonListPetsInOut.SelectedValue = dt.Rows[0]["petsinandout"].ToString();

            

            //dt.Rows[0]["LastName"].ToString();
            
        }

        Trace.Write("connectionString: " + connectionString);

    }

    protected void disableAddress()
    {
        tbAddress.Enabled = false;
        tbAddressLine2.Enabled = false;
        tbCity.Enabled = false;
        ddlState.Enabled = false;
        tbZip.Enabled = false;
    }

    protected void enableAddress()
    {
        tbAddress.Enabled = true;
        tbAddressLine2.Enabled = true;
        tbCity.Enabled = true;
        ddlState.Enabled = true;
        tbZip.Enabled = true;
    }


    protected void bEditCurrentAddress_Click(object sender, EventArgs e)
    {
        enableAddress();
        bIsNewAddress = false;
    }

    protected void bAddNewAddress_Click(object sender, EventArgs e)
    {
        enableAddress();

        tbAddress.Text = "";
        tbAddressLine2.Text = "";
        tbCity.Text = "";
        ddlState.SelectedIndex = 0;
        tbZip.Text = "";

        bIsNewAddress = true;
    }
}
