
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
            updateFamilyList();
        }

        futureDateValidator.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");

        if (rblOwnerOccupied.SelectedValue == "0")
        {
            pnlOwnerContactInformation.Visible = true;
            tbOwnerContactInformation.Enabled = true;
        }
        else
        {
            tbOwnerContactInformation.Text = "";
            pnlOwnerContactInformation.Visible = false;
        }


    }

    protected void updateLanguage()
    {
        
        Trace.Write("connectionString: " + connectionString);

        SqlConnection con = new SqlConnection(connectionString);

        string com = "Select LanguageID,LanguageName from dbo.Language order by LanguageName asc";

        SqlDataAdapter adpt = new SqlDataAdapter(com, con);

        DataTable dt = new DataTable();

        adpt.Fill(dt);

        
    }

    protected void updateFamilyList()
    {
        SqlConnection con = new SqlConnection(connectionString);

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

        FamilyNameList.DataTextField = "NameAddress";
        FamilyNameList.DataValueField = "FamilyID";

        FamilyNameList.DataBind();
        FamilyNameList.Items.Insert(0, "(Family name -- PRIMARY residence)");

        Trace.Write("connectionString: " + connectionString);

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
            if (tbPrimaryPhone.Text != "")
                command.Parameters.Add("@New_PrimaryPhone", SqlDbType.BigInt).Value = Convert.ToInt64(tbPrimaryPhone.Text);
            if (tbSecondaryPhone.Text != "")
                command.Parameters.Add("@New_SecondaryPhone", SqlDbType.BigInt).Value = Convert.ToInt64(tbSecondaryPhone.Text);
            command.Parameters.Add("@New_Pets", SqlDbType.TinyInt).Value = Convert.ToInt16(ddlPets.SelectedValue);

            command.Parameters.Add("@New_Number_of_Smokers", SqlDbType.TinyInt).Value = Convert.ToInt16(ddlSmokers.SelectedValue);

            command.Parameters.Add("@New_Pets_in_and_out", SqlDbType.Bit).Value = Convert.ToInt16(RadioButtonListPetsInOut.SelectedValue);

            if (tbFamilyNotes.Text != "")
                command.Parameters.Add("@New_Family_Notes", SqlDbType.VarChar).Value = tbFamilyNotes.Text;

            command.Parameters.Add("@isNewAddress", SqlDbType.Bit).Value = Convert.ToInt16(bIsNewAddress);

            if (tbDateBuilt.Text != "")
                command.Parameters.Add("@New_Year_Built", SqlDbType.DateTime).Value = tbDateBuilt.Text;

            if (tbOwnerContactInformation.Text != "")
                command.Parameters.Add("@New_OwnerContactInformation", SqlDbType.VarChar).Value = tbOwnerContactInformation.Text;

            Trace.Write("FamilyNameList.SelectedValue.ToString(): " + FamilyNameList.SelectedValue.ToString());

            command.Parameters.Add("@Family_ID", SqlDbType.Int).Value = Convert.ToInt16(FamilyNameList.SelectedValue.ToString());

            command.Parameters.Add("@DEBUG", SqlDbType.Bit).Value = 1;

            
            command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sqlConnection.Open();

            int rownum = 0;

            try
            {
                rownum = command.ExecuteNonQuery();

                String sReturnValue = command.Parameters["@ReturnValue"].Value.ToString();

                Trace.Write("sReturnValue: " + sReturnValue);

                if (sReturnValue == "0")
                {
                    lbOutput.Text = "Existing Family #" + FamilyNameList.SelectedValue.ToString() + " Updated at: " + DateTime.Now;
                    lbPopUp.Text = lbOutput.Text;

                    //NextButton.Visible = true;
                    ModalPopupExtender1.Show();

                    //updateFamilyList();

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
        tbOwnerContactInformation.Text = "";
        tbAddress.Text = "";
        tbAddressLine2.Text = "";
        tbCity.Text = "";
        tbDateBuilt.Text = "";
        tbFamilyNotes.Text = "";
        tbPrimaryPhone.Text = "";
        tbSecondaryPhone.Text = "";
        tbZip.Text = "";
        ddlPets.SelectedIndex = 0;
        ddlSmokers.SelectedIndex = 0;
        ddlState.SelectedIndex = 6; //Colorado

    }


    protected void getFamilyDetails(String sFamilyIDIn)
    {

        //resetFields();

        SqlConnection conFamilyDetails = new SqlConnection(connectionString);

        string comFamilyDetails = @"exec usp_SLEditFamilyWebScreenInformation @Family_ID='" + sFamilyIDIn + "'";


        SqlDataAdapter adptFamilyDetails = new SqlDataAdapter(comFamilyDetails, conFamilyDetails);

        DataTable dtFamilyDetails = new DataTable();

        adptFamilyDetails.Fill(dtFamilyDetails);

        //fill UI screen with pre-selected values
        if (dtFamilyDetails.Rows.Count > 0)
        {

            pnlEditAddress.Visible = true;

            btnUpdate.Visible = true;

            tbLastName.Text = dtFamilyDetails.Rows[0]["LastName"].ToString();
            tbAddress.Text = dtFamilyDetails.Rows[0]["AddressLine1"].ToString();
            tbAddressLine2.Text = dtFamilyDetails.Rows[0]["AddressLine2"].ToString();
            tbCity.Text = dtFamilyDetails.Rows[0]["city"].ToString();

            if ((dtFamilyDetails.Rows[0]["State"].ToString() != null) && (ddlState.Items.FindByValue(dtFamilyDetails.Rows[0]["State"].ToString().Trim()) != null))
            {
                ddlState.SelectedValue = dtFamilyDetails.Rows[0]["State"].ToString().Trim();
            }
            else
            {
                ddlState.SelectedIndex = 0;
            }
            
            tbZip.Text = dtFamilyDetails.Rows[0]["zipCode"].ToString();

            if (dtFamilyDetails.Rows[0]["YearBuilt"].ToString() != null && dtFamilyDetails.Rows[0]["YearBuilt"].ToString() != "")
            {
                tbDateBuilt.Text = Convert.ToDateTime(dtFamilyDetails.Rows[0]["YearBuilt"].ToString()).ToString("MM/dd/yyyy");
            }
            else
            {
                tbDateBuilt.Text = "";
            }

            if ((dtFamilyDetails.Rows[0]["OwnerContactInformation"].ToString() != null))
            {
                tbOwnerContactInformation.Text = dtFamilyDetails.Rows[0]["OwnerContactInformation"].ToString();
            }
            else
            {
                tbOwnerContactInformation.Text = "";
            }

            tbPrimaryPhone.Text = dtFamilyDetails.Rows[0]["PrimaryPhoneNumber"].ToString();
            tbSecondaryPhone.Text = dtFamilyDetails.Rows[0]["SecondaryPhoneNumber"].ToString();

            if ((dtFamilyDetails.Rows[0]["NumberofSmokers"].ToString() != null) && (ddlSmokers.Items.FindByValue(dtFamilyDetails.Rows[0]["NumberofSmokers"].ToString().Trim()) != null))
            {
                ddlSmokers.SelectedValue = dtFamilyDetails.Rows[0]["NumberofSmokers"].ToString().Trim();
            }
            else
            {
                ddlSmokers.SelectedIndex = 0;
            }

            if ((dtFamilyDetails.Rows[0]["Pets"].ToString() != null) && (ddlPets.Items.FindByValue(dtFamilyDetails.Rows[0]["Pets"].ToString().Trim()) != null))
            {
                ddlPets.SelectedValue = dtFamilyDetails.Rows[0]["Pets"].ToString().Trim();
                RadioButtonListPetsInOut.Enabled = true;
            }
            else
            {
                ddlPets.SelectedIndex = 0;
            }


            if ((dtFamilyDetails.Rows[0]["Petsinandout"].ToString() != null) && (ddlPets.Items.FindByValue(dtFamilyDetails.Rows[0]["Pets"].ToString().Trim()) != null))
            {
                //ddlPets.SelectedValue = dtFamilyDetails.Rows[0]["Petsinandout"].ToString().Trim();
                RadioButtonListPetsInOut.SelectedValue = dtFamilyDetails.Rows[0]["petsinandout"].ToString();
                RadioButtonListPetsInOut.Enabled = true;
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
        tbDateBuilt.Enabled = false;
        rblOwnerOccupied.Enabled = false;
        tbOwnerContactInformation.Enabled = false;
    }

    protected void enableAddress()
    {
        tbAddress.Enabled = true;
        tbAddressLine2.Enabled = true;
        tbCity.Enabled = true;
        ddlState.Enabled = true;
        tbZip.Enabled = true;
        tbDateBuilt.Enabled = true;
        rblOwnerOccupied.Enabled = true;
        tbOwnerContactInformation.Enabled = true;
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
