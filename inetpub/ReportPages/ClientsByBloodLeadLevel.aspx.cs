using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;



public partial class ReportPages_ResearchSubjectByAge : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["csLCCHP"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SqlConnection MyConnection = new SqlConnection(connectionString);

            //SqlCommand MyCommand = new SqlCommand("select * from sysobjects where id = object_id(N'usp_SLAllBloodTestResults')" +
            //"  and OBJECTPROPERTY(id, N'IsProcedure') = 1", MyConnection);

            //// Set the command type that you will run.
            //MyCommand.CommandType = CommandType.Text;

            //// Open the connection.
            //MyCommand.Connection.Open();

            //// Run the SQL statement, and then get the returned rows to the DataReader.
            //SqlDataReader MyDataReader = MyCommand.ExecuteReader();

            //// If any rows are returned, the stored procedure that you are trying 
            //// to create already exists. Therefore, try to create the stored procedure
            //// only if it does not exist.
            //if (!MyDataReader.Read())
            //{
            //    //MyCommand.CommandText = "create procedure GetAuthorsByLastName" + 
            //    //    " (@au_lname varchar(40), select * from authors where" +
            //    //    " au_lname like @au_lname; select @RowCount=@@ROWCOUNT";
            //    //MyDataReader.Close();
            //    //MyCommand.ExecuteNonQuery();
            //}
            //else
            //{
            //    MyDataReader.Close();
            //}

            //MyCommand.Dispose();  //Dispose of the Command object.
            //MyConnection.Close(); //Close the connection.
        }

        // Add the event handler to the Button_Click event.
        //	this.Button1.Click += new System.EventHandler(this.Button1_Click);
    }


    
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        //DataSet DS = new DataSet();

        //ReportDataSource rds = new ReportDataSource("ClientBLLs", DS.Tables);
        //ReportViewer1.LocalReport.DataSources.Clear();

        //ReportParameter Min_Lead_Value = new ReportParameter("Min_Lead_Value", TextBox1.Text.ToString());

        //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { Min_Lead_Value });
        //ReportViewer1.LocalReport.DataSources.Add(rds);
        //ReportViewer1.LocalReport.Refresh();
          
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection MyConnection = new SqlConnection(connectionString);

        SqlDataAdapter MyDataAdapter = new SqlDataAdapter("usp_SLAllBloodTestResults", MyConnection);

        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

        MyDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Min_Lead_Value", SqlDbType.Decimal));

        MyDataAdapter.SelectCommand.Parameters["@Min_Lead_Value"].Value = TextBox1.Text;

        DataSet DS = new DataSet();

        MyDataAdapter.Fill(DS, "ClientsByBLL");

        GridView1.DataSource = DS.Tables["ClientsByBLL"].DefaultView;

        //GridView1.DataBind();


        // Testing reloading the ReportViewer
            //MyDataSetTableAdapters.TestProcedureTableAdapter ta = new MyDataSetTableAdapters.TestProcedureTableAdapter();
            //MyDataSet.TestProcedureDataTable dt = new MyDataSet.TestProcedureDataTable();
            //ta.Fill(dt, Convert.ToInt16(TextBox1.Text));
            //ReportDataSource rds = new ReportDataSource();
            //rds.Name = "DataSet1";
            //rds.Value = dt;

            //ReportParameter rp = new ReportParameter("Parameter1", TextBox1.Text.ToString());

            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            //ReportViewer1.LocalReport.DataSources.Add(rds);
            //ReportViewer1.LocalReport.Refresh();

       // ReportViewer1.LocalReport.DataSources.Clear();
      //  ReportViewer1.Reset();
        ReportViewer1.LocalReport.ReportPath = @"Reports\ClientsByBloodLeadLevelOcean.rdlc";
        
        ReportDataSource rds = new ReportDataSource("ClientBLLs", DS.Tables["ClientsByBLL"]);
        
        ReportParameter Min_Lead_Value = new ReportParameter("Min_Lead_Value", TextBox1.Text.ToString());
        
       ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { Min_Lead_Value });
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.DataBind();

       ReportViewer1.LocalReport.Refresh();
       
       TextBox2.Text = TextBox1.Text;


  MyDataAdapter.Dispose();
        MyConnection.Close();

    }
}