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

public partial class AddFamily : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //updateLanguage();
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
            SqlCommand command = new SqlCommand("usp_InsertNewFamilyWebScreen", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FamilyLastName", SqlDbType.VarChar).Value = tbLastName.Text;
            command.Parameters.Add("@StreetNum", SqlDbType.VarChar).Value = TextBoxStreetNumber.Text;
            command.Parameters.Add("@StreetName", SqlDbType.VarChar).Value = TextBoxStreetName.Text;
            command.Parameters.Add("@StreetSuff", SqlDbType.VarChar).Value = DropDownListStreetSuffix.Text;
            command.Parameters.Add("@ApartmentNum", SqlDbType.VarChar).Value = TextBoxApartmentNumber.Text;
            command.Parameters.Add("@CityName", SqlDbType.VarChar).Value = TextBoxCity.Text;

            command.Parameters.Add("@StateAbbr", SqlDbType.VarChar).Value = ddlState.SelectedValue;
            command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = TextBoxZip.Text;
            if (HomePhoneTextBox.Text != "")
                command.Parameters.Add("@HomePhone", SqlDbType.BigInt).Value = Convert.ToInt64(HomePhoneTextBox.Text);
            if (WorkPhoneTextBox.Text != "")
                command.Parameters.Add("@WorkPhone", SqlDbType.BigInt).Value = Convert.ToInt64(WorkPhoneTextBox.Text);
            command.Parameters.Add("@Pets", SqlDbType.Bit).Value = Convert.ToInt16(RadioButtonListPets.SelectedValue);
            command.Parameters.Add("@inandout", SqlDbType.Bit).Value = Convert.ToInt16(RadioButtonListPetsInOut.SelectedValue);
           command.Parameters.Add("@OtherNotes", SqlDbType.VarChar).Value = TextBoxOtherNotes.Text;

            command.Parameters.Add("@FamilyID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion
      
            sqlConnection.Open();

            int rownum = 0;

            try
            {
               rownum = command.ExecuteNonQuery();

               String sID = command.Parameters["@FamilyID"].Value.ToString();

               Trace.Write("sID: " + sID);

               if (sID != "")
               {
                   lbOutput.Text = "New Family #" + sID + " Inserted at: " + DateTime.Now;
                   lbPopUp.Text = lbOutput.Text;

                   NextButton.Visible = true;
                   ModalPopupExtender1.Show();
               }
               else
               {
                   lbOutput.Text = "Failed to Insert New Family";
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
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() + " "+ DateTime.Now;
            Trace.Write("SQL Error" + exSQL.Message.ToString());

        }
        catch (Exception ex)
        {
            lbOutput.Text = "ERROR: " + ex.Message.ToString() + " " + DateTime.Now;
            Trace.Write("Error" + ex.Message.ToString());
        }

    }

    protected void NextButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddClient.aspx");
    }
   
}
