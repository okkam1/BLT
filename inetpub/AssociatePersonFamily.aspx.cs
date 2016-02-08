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
            GetPeopleFamilyAssociations();
        }

        lbOutput.Text = "";

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
                ddlFamily.DataSource = dt_family;

                ddlFamily.DataTextField = "FamilyProperty";
                ddlFamily.DataValueField = "FamilyID";
                ddlFamily.DataBind();

                ListItem itemHyphen = new ListItem();
                itemHyphen.Text = "-";
                itemHyphen.Value = "-";

                ddlFamily.Items.Insert(0, "-");

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

    protected void rblWithoutFamily_Changed(object sender, EventArgs e)
    {
        GetPeople();
        GetFamilies();
        GetPeopleFamilyAssociations();
    }

    protected void ddlFamilyChanged(object sender, EventArgs e)
    {
        lbOutput.Text = "";
    }

    protected void ddlPeopleChanged(object sender, EventArgs e)
    {
        GetPeopleFamilyAssociations();
        lbOutput.Text = "";
        //Reset_rblWithoutFamily();
    }

    private void Reset_rblWithoutFamily()
    {
        throw new NotImplementedException();
    }


    protected void GetPeople()
    {
        SqlConnection sqlConnection_people = new SqlConnection(connectionString);

        SqlCommand command_people = new SqlCommand("usp_SlListPersonBaseDetails", sqlConnection_people);
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
                   
                    // Refresh the datagrid contents
                    GetPeopleFamilyAssociations();
                    GetPeople();
                    ddlFamily.SelectedIndex = 0;

                }

                else if (sReturnValue == "2627")
                {   lbOutput.Text = "Nothing to do, The Person and Family were already associated.";
                }
                else
                {
                    lbOutput.Text = "Failed to Create Family Association. SQL Error code" + @sReturnValue;
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

    protected void GetPeopleFamilyAssociations()
    {
        SqlDataSource_PersontoFamilies.SelectParameters["PersonID"].DefaultValue = ddlPeople.SelectedValue.ToString();

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
    }

}