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

        //SqlDataSource1.SelectParameters.Add("@PersonID", ddlFamilyMembers.SelectedValue);
        SqlDataSource1.SelectParameters["PersonID"].DefaultValue = ddlFamilyMembers.SelectedValue.ToString();

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

        Response.Redirect("BloodTestResults.aspx");

    }
}