﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Questionnaire : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["csLeadTrackingProgram2"].ConnectionString;

        Trace.Write("connectionString: " + connectionString);

        SqlConnection con = new SqlConnection(connectionString);

        if (!Page.IsPostBack)
        {
            //set default date to today
            tbQuestionnaireDate.Text = DateTime.Today.ToShortDateString();

            cvFuturePaintDate.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
            cvFutureQuestionnaireDate.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
            cvFutureRemodelDate.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");

            string FirstName = (string)(Session["FirstName"]);
            string LastName = (string)(Session["LastName"]);
            string ClientID = (string)(Session["ClientID"]);

            lblHeader.Text += "for " + FirstName + " " + LastName + " (" + ClientID + ") ";

            //fill daycare drop down
            /*
            SqlConnection conLang = new SqlConnection(connectionString);

            string comLang = "Select LanguageID, Upper(LanguageName) as LanguageName from dbo.Language order by LanguageName asc";

            SqlDataAdapter adptLang = new SqlDataAdapter(comLang, conLang);

            DataTable dtLang = new DataTable();

            adptLang.Fill(dtLang);

            ddlDayCare.DataSource = dtLang;

            ddlDayCare.DataBind();

            ddlDayCare.DataTextField = "LanguageName";
            ddlDayCare.DataValueField = "LanguageID";

            ddlDayCare.DataBind();
            // if (!Page.IsPostBack)
            ddlDayCare.Items.Insert(0, "-");

            */


        }

        ddlDayCare.Items.Insert(0, "-");
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
            SqlCommand command = new SqlCommand("usp_InsertNewQuestionnaireWebScreen", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Person_ID", SqlDbType.Int).Value = Convert.ToInt32(ClientID);
            command.Parameters.Add("@QuestionnaireDate", SqlDbType.DateTime).Value = tbQuestionnaireDate.Text;
            command.Parameters.Add("@PaintPeeling", SqlDbType.Bit).Value = Convert.ToByte(rblPaintPeeling.SelectedValue);
            if (tbPaintDate.Text!="")
                command.Parameters.Add("@PaintDate", SqlDbType.Date).Value = tbPaintDate.Text;
            command.Parameters.Add("@VisitRemodel", SqlDbType.Bit).Value = Convert.ToByte(rblVisitRemodel.SelectedValue);
            if (tbRemodelDate.Text!="")
                command.Parameters.Add("@RemodelDate", SqlDbType.Date).Value = tbRemodelDate.Text;
            command.Parameters.Add("@Vitamins", SqlDbType.Bit).Value = Convert.ToByte(rblVitamins.SelectedValue);
            command.Parameters.Add("@HandWash", SqlDbType.Bit).Value = Convert.ToByte(rblHandWash.SelectedValue);
            command.Parameters.Add("@Bottle", SqlDbType.Bit).Value = Convert.ToByte(rblBottle.SelectedValue);
            command.Parameters.Add("@Nursing", SqlDbType.Bit).Value = Convert.ToByte(rblNursing.SelectedValue);
            command.Parameters.Add("@Pacifier", SqlDbType.Bit).Value = Convert.ToByte(rblPacifier.SelectedValue);
            command.Parameters.Add("@BitesNails", SqlDbType.Bit).Value = Convert.ToByte(rblBiteNails.SelectedValue);
            command.Parameters.Add("@EatsOutdoors", SqlDbType.Bit).Value = Convert.ToByte(rblEatOutdoors.SelectedValue);
            command.Parameters.Add("@NonFoodInMouth", SqlDbType.Bit).Value = Convert.ToByte(rblNonFoodInMouth.SelectedValue);
            command.Parameters.Add("@EatsNonFood", SqlDbType.Bit).Value = Convert.ToByte(rblEatsNonFood.SelectedValue);
            command.Parameters.Add("@SucksThumb", SqlDbType.Bit).Value = Convert.ToByte(rblSucksThumb.SelectedValue);
            command.Parameters.Add("@Mouthing", SqlDbType.Bit).Value = Convert.ToByte(rblMouthing.SelectedValue);
            command.Parameters.Add("@DaycareID", SqlDbType.Int).Value = ddlDayCare.SelectedValue;
            command.Parameters.Add("@DayCareNotes", SqlDbType.VarChar).Value = tbDaycareNotes.Text;
            command.Parameters.Add("@Source", SqlDbType.Int).Value = Convert.ToInt32(rblSource.SelectedValue);
            command.Parameters.Add("@QuestionnaireNotes", SqlDbType.VarChar).Value = tbQuestionnaireNotes.Text;

            command.Parameters.Add("@Questionnaire_return_value", SqlDbType.Int).Direction = ParameterDirection.Output;  //usp returns ID upon completion

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            String returnValue = command.Parameters["@Questionnaire_return_value"].Value.ToString();

            Trace.Write("returnValue: " + returnValue);

            if (returnValue != "")
            {
                lbOutput.Text = "New Questionnaire data " + returnValue + " Inserted at: " + DateTime.Now;

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
        Response.Redirect("BloodTestResults.aspx");
    }

}