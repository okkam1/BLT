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

public partial class BloodTestResultsDataGrid : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        con = new SqlConnection(connectionString);
        cmd.CommandText = "Select BloodTestResultsID, isBaseline, PersonID, SampleDate, LabSubmissionDate, LeadValue from BloodTestResults";
        cmd.Connection = con;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Open();
        cmd.ExecuteNonQuery();
        Grid.DataSource = ds;
        Grid.DataBind();
        con.Close();
    }
    protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
//        Grid.CurrentPageIndex = e.NewPageIndex;
//        BindData();
    }
    protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
    {
//        Grid.EditItemIndex = e.Item.ItemIndex;
//        BindData();
    }
    protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
    {
//        Grid.EditItemIndex = -1;
//        BindData();
    }
    protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
/*        con = new SqlConnection(connectionString);
        cmd.Connection = con;
        int BloodTestResultsID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
        cmd.CommandText = "Delete from BloodTestResults where BloodTestResultsID=" + BloodTestResultsID;
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        Grid.EditItemIndex = -1;
        BindData();
 */
    }
    protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        con = new SqlConnection(connectionString);


/* 
BloodTestResultsID	int identity
isBaseline	bit
PersonID	int
SampleDate	date
LabSubmissionDate	date
LeadValue	numeric
LeadValueCategoryID	tinyint
HemoglobinValue	numeric
HemoglobinValueCategoryID	tinyint
HematocritValueCategoryID	tinyint
LabID	int
BloodTestCosts	money
SampleTypeID	tinyint
TakenAfterPropertyRemediationCompleted	bit
ModifiedDate	datetime
CreatedDate	datetime
HematocritValue	numeric
ExcludeResult	bit
HistoricBloodTestResultsID	int
HistoricLabResultsID	varchar
*/

        cmd.Parameters.Add("@BloodTestResultsId", SqlDbType.Int).Value = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
        cmd.Parameters.Add("@isBaseline", SqlDbType.Bit).Value = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
        cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
        cmd.Parameters.Add("@SampleDate", SqlDbType.Date).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
        cmd.Parameters.Add("@LabSubmissionDate", SqlDbType.Date).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
        cmd.Parameters.Add("@LeadValue", SqlDbType.Float).Value = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
        cmd.CommandText = "Update BloodTestResults set F_Name=@F_Name,L_Name=@L_Name,City=@City,EmailId=@EmailId,EmpJoining=@EmpJoining where EmpId=@EmpId";
        cmd.Connection = con;
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        Grid.EditItemIndex = -1;
        BindData();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand cmd;
        cmd = new SqlCommand("Insert into Employee (EmpId,F_Name,L_Name,City,EmailId,EmpJoining) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        BindData1();
    }
    public void BindData1()
    {
        con = new SqlConnection(connectionString);
        cmd.CommandText = "Select BloodTestResultsID, isBaseline, PersonID, SampleDate, LabSubmissionDate, LeadValue from BloodTestResults";
        cmd.Connection = con;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Open();
        cmd.ExecuteNonQuery();
        Grid1.DataSource = ds;
        Grid1.DataBind();
        con.Close();
    }
}