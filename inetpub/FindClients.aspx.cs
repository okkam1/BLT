using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class autoCompleteTest : System.Web.UI.Page
{ 
    protected void SearchByTagButton_Click(object sender, EventArgs e)
    {

        GetClients();
    }

    protected void GetClients()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        SqlCommand command = new SqlCommand("usp_findPerson", conn);

        command.CommandType = CommandType.StoredProcedure;

        try
        {
            command.Parameters.Add(new SqlParameter("@FirstName", tbFirstName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@LastName", tbLastName.Text.Trim()));
            if (tbPersonID.Text.Length > 0) { command.Parameters.Add(new SqlParameter("@PersonID", tbPersonID.Text.Trim())); }

            if (ddlYear.SelectedValue != "-")
            {
                command.Parameters.Add(new SqlParameter("@BirthYear", ddlYear.SelectedItem.Value));
            }
            if (ddlMonth.SelectedValue != "-")
            {
                command.Parameters.Add(new SqlParameter("@BirthMonth", ddlMonth.SelectedIndex));
            }
            if (ddlDay.SelectedValue != "-")
            {
                command.Parameters.Add(new SqlParameter("@Birthday", ddlDay.SelectedValue));
            }

            using (SqlDataReader rdr = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);

                gvClients.DataSource = dt;
                gvClients.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            //Connection Object Closed
            conn.Close();
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> SearchFirstName(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["csLCCHP"].ConnectionString;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct FirstName from Person where " +
                "FirstName like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> names = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        names.Add(sdr["FirstName"].ToString());
                    }
                }
                conn.Close();
                return names;
            }
        }
    }

    
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> SearchLastName(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["csLCCHP"].ConnectionString;

            using (SqlCommand cmd = new SqlCommand())
            {
                string cmdText = "select distinct LastName from Person where " +
                "LastName like @SearchText + '%'";

                //    cmd.CommandText = "select distinct LastName from Person where " +
                //"LastName like @SearchText + '%'";
                
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                if (contextKey != "0")
                {
                    cmdText += " and FirstName like @FirstName + '%'";
                    cmd.Parameters.AddWithValue("@FirstName", contextKey);
                }
                cmd.CommandText = cmdText;
                

                cmd.Connection = conn;
                conn.Open();
                List<string> names = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        names.Add(sdr["LastName"].ToString());
                    }
                }
                conn.Close();
                return names;
            }
        }
 
    }

    
    
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
           // string $currentYear = System.DateTime.Now.Year.ToString();

            int currentYear = System.DateTime.Now.Year;

            //Fill Years
            for (int i = currentYear; i >= (currentYear - 80); i--)
            {
                ddlYear.Items.Add(i.ToString());
            }
            // add default entry to year drop down - nothing to filter on
            ddlYear.Items.Insert(0, "-");

            //Fill days
            FillDays();
        }

    }

    private void FillDays()
    {
                ddlDay.Items.Clear();

        //getting number of days in selected month & year
        if ((ddlYear.SelectedValue != "-") && (ddlMonth.SelectedValue != "-"))
        {
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedIndex));
            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                ddlDay.Items.Add(i.ToString());
            }
            // add default entry to month drop down - nothing to filter on
            ddlDay.Items.Insert(0, "-");
        }
        else
        {
            ddlDay.Items.Insert(0, "-");
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDays();
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
      FillDays();
     }

    protected void gvClients_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClients.PageIndex = e.NewPageIndex;

        GetClients();

    }
}

