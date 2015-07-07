using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddEthnicity : System.Web.UI.UserControl
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

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
            SqlCommand command = new SqlCommand("[usp_InsertEthnicity]", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Ethnicity", SqlDbType.VarChar).Value = tbEthnicity.Text.ToUpper();
            command.Parameters.Add("@NewEthnicityID", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            sqlConnection.Open();

            int rownum = 0;

            rownum = command.ExecuteNonQuery();

            String sID = command.Parameters["@NewEthnicityID"].Value.ToString();

            Trace.Write("sID: " + sID);

            if (sID != "")
            {
                lbOutput.Text = "New Ethnicity #" + sID + " Inserted at: " + DateTime.Now;
              //  lbPopUp.Text = lbOutput.Text;

              //  NextButton.Visible = true;
              //  ModalPopupExtender1.Show();
            }
            else
            {
                lbOutput.Text = "Failed to Insert New Ethnicity";
               // lbPopUp.Text = lbOutput.Text;
              //  ModalPopupExtender1.Show();
            }

            sqlConnection.Close();


        }
        catch (SqlException exSQL)
        {
            lbOutput.Text = "SQL ERROR: " + exSQL.Message.ToString() + " " + DateTime.Now;

          //  lbPopUp.Text = lbOutput.Text;
           // ModalPopupExtender1.Show();

            Trace.Write("SQL Error" + exSQL.Message.ToString());

        }
        catch (Exception ex)
        {
            lbOutput.Text = "ERROR: " + ex.Message.ToString() + " " + DateTime.Now;

          //  lbPopUp.Text = lbOutput.Text;
           // ModalPopupExtender1.Show();

            Trace.Write("Error" + ex.Message.ToString());
        }


    }

}