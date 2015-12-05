using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AssociatePersonFamily : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //  Trace.Write("connectionString: " + connectionString);
        if (!Page.IsPostBack)
        {
            GetPeople();
            GetFamilies();
        }

        lbOutput.Text = "";

    }

    protected void GetFamilies()
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
            ddlFamily.DataSource = dt_family;

            ddlFamily.DataTextField = "FamilyProperty";
            ddlFamily.DataValueField = "FamilyID";
            ddlFamily.DataBind();

            ListItem itemHyphen = new ListItem();
            itemHyphen.Text="0";
            itemHyphen.Value="0";

            ddlFamily.Items.Insert(0, "-");

        }
    }

    protected void rblWithoutFamily_Changed(object sender, EventArgs e)
    {
        GetPeople();
    }

    protected void GetPeople()
    {
        SqlConnection sqlConnection_people = new SqlConnection(connectionString);

        SqlCommand command_people = new SqlCommand("usp_SlListPersonandFamilies", sqlConnection_people);
        command_people.CommandType = CommandType.StoredProcedure;
        command_people.Parameters.Add("@WithoutFamily", SqlDbType.Bit).Value = Convert.ToByte(rblWithoutFamily.SelectedValue);

        sqlConnection_people.Open();
        command_people.ExecuteNonQuery();
        sqlConnection_people.Close();

        using (SqlDataAdapter da_people = new SqlDataAdapter(command_people))
        {
            DataTable dt_people = new DataTable();
            da_people.Fill(dt_people);
            ddlPeople.DataSource = dt_people;

            ddlPeople.DataTextField = "Person";
            ddlPeople.DataValueField = "PersonID";
            ddlPeople.DataBind();

        }

    }

    protected void bAssociateFamilies_Click(object sender, EventArgs e)
    {
        if (ddlFamily.SelectedValue == "-")
        {
            
            lbOutput.Text = "Please select a valid family.";

        } 
        else
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("usp_InsertPersontoFamily", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            lbOutput.Text = ddlFamily.SelectedValue;

            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = Int32.Parse(ddlPeople.SelectedItem.Value);
            command.Parameters.Add("@FamilyID", SqlDbType.Int).Value = Int32.Parse(ddlFamily.SelectedItem.Value);

            command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            int rownum = 0;

            try
            {
                sqlConnection.Open();

                rownum = command.ExecuteNonQuery();

                String sReturnValue = command.Parameters["@ReturnValue"].Value.ToString();

                Trace.Write("sReturnValue: " + sReturnValue);

                sqlConnection.Close();

                if (sReturnValue == "0")
                {
                    lbOutput.Text = "New Family Association Successfully Created at: " + DateTime.Now;

                    GetPeople();
                    ddlFamily.SelectedIndex = 0;

                }

                else
                {
                    lbOutput.Text = "Failed to Create Family Association.";

                }


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
    } 
}