using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class EditQuestionnaire : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        Trace.Write("connectionString: " + connectionString);

        if (!Page.IsPostBack)
        {
            GetFamilies();

            Trace.Write("connectionString: " + connectionString);

        }

    }

    protected void getFamilyMembers(String sFamilyIDIn)
    {
        if (FamilyNameList.SelectedIndex != 0)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string com = "select PersonID,FirstName,MiddleName from person where PersonID in (select PersonID from persontoFamily where FamilyID = '" + sFamilyIDIn + "') order by Person.FirstName";


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
            }

        }
    }

    protected void FamilyNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlFamilyMembers.Visible = false;
        getFamilyMembers(FamilyNameList.SelectedValue);

        GridView1.Visible = false;
        btnInsertResults.Visible = false;
    }


    protected void ddlFamilyMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get indivifual
        // getIndividual(ddlFamilyMembers.SelectedValue.ToString());

        //SqlDataSource1.SelectParameters.Add("PersonID", ddlFamilyMembers.SelectedValue);
        SqlDataSource1.SelectParameters["PersonID"].DefaultValue = ddlFamilyMembers.SelectedValue.ToString();

        //Trace.Write("@PersonID: " + SqlDataSource1.SelectParameters.GetValues.to

        gridText.Text = "";

        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            GridView1.Visible = true;
        }
        else
        {
            gridText.Text = "No Results Found";
        }

        btnInsertResults.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["FirstName"] = ddlFamilyMembers.SelectedItem.ToString();
        Session["LastName"] = FamilyNameList.SelectedItem.ToString();
        Session["ClientID"] = ddlFamilyMembers.SelectedValue.ToString();
        Session["PageFrom"] = "EditBloodLeadResults.aspx";

        Response.Redirect("Questionnaire.aspx");

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
}