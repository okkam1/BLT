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

            string sPersonID = Request.QueryString["pid"];
            string sFamilyID = "";

            if (sPersonID != "" && sPersonID != null)
            {
                Trace.Write("sPersonID: " + sPersonID);

                //call to DB to get FamilyID based on PersonID Lookup
                sFamilyID = getFamilyID(sPersonID);

                if (sFamilyID != "")
                {
                    //set drop-down to correct family
                    FamilyNameList.SelectedValue = @sFamilyID;

                    //show other family members in dropdown
                    resetFields();
                    pnlFamilyMembers.Visible = false;
                    getFamilyMembers(FamilyNameList.SelectedValue);
                    ddlFamilyMembers.SelectedValue = sPersonID;


                    //call getIndividual to populate Person Information
                    getIndividual(@sPersonID);
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
                else
                {
                    //show error because family not found (PersonID not valid?)

                    lbOutput.Text = "Unable to find a family for Person ID:  " + sPersonID + " " + DateTime.Now;
                    // AddAnother.Visible = false;
                    lbPopUp.Text = "Unable to find a family for Person ID:  " + sPersonID + " " + DateTime.Now; //lbOutput.Text;

                    ModalPopupExtender1.Show();

                    Trace.Write(lbOutput.Text);


                }
            }
            Trace.Write("connectionString: " + connectionString);

        }

    }

    protected string getFamilyID(string sPersonIDIn)
    {
        string sFamilyID = "";

        if (sPersonIDIn != "" && sPersonIDIn != null)
        {

            Int32 iFamilyID = Int32.Parse(sPersonIDIn);

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("usp_SLPersontoFamilyID", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = iFamilyID;

            //command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            command.Parameters.Add("@FamilyID", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            sFamilyID = command.Parameters["@FamilyID"].Value.ToString();
        }

        Trace.Write("sFamilyID: " + sFamilyID);

        return sFamilyID;

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

    protected void resetFields()
    {

    }

    protected void getIndividual(String sPersonIDIn)
    {

        resetFields();

        SqlConnection con = new SqlConnection(connectionString);

        string com = @"select *,
(select top 1 LanguageID from PersontoLanguage ptl where p.personid = ptl.personid order by CreatedDate DESC) as LanguageID,
(select top 1 EthnicityID from PersontoEthnicity pte where p.personid = pte.personid  order by CreatedDate DESC) as EthnicityID,
CAST (OutofSite as varchar) as OutofSiteV,
CAST (isClient as varchar) as isClientV,
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
            ddlFamilyMembers.SelectedValue = sPersonIDIn;


        }

        Trace.Write("connectionString: " + connectionString);

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