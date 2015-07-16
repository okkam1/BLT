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
    String MinLeadValue = "-3.3";
    String MaxLeadvalue = "100.0";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            tbMinLeadValue.Text = "-3.3"; //  DateTime.Today.ToString("MM/dd/yyyy");
            tbMaxLeadValue.Text = "100.0"; // DateTime.Today.AddMonths(1).ToString("MM/dd/yyyy");
        }
        //if (tbMinLeadValue != "")
        ClientsByBloodLeadLevelDataSet1.SelectParameters["Min_Lead_Value"].DefaultValue = tbMinLeadValue.Text;
        ClientsByBloodLeadLevelDataSet1.SelectParameters["Max_Lead_Value"].DefaultValue = tbMaxLeadValue.Text;
    }

    protected void btnApplyLeadValueFilter_Click(object sender, EventArgs e)
    {
        if (tbMinLeadValue.Text != "")
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Min_Lead_Value"].DefaultValue = tbMinLeadValue.Text;
        else
        {
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Min_Lead_Value"].DefaultValue = MinLeadValue;
            tbMinLeadValue.Text = "-3.3";
        }
        if (tbMaxLeadValue.Text != "")
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Max_Lead_Value"].DefaultValue = tbMaxLeadValue.Text;
        else
        {
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Max_Lead_Value"].DefaultValue = "100.0";
            tbMaxLeadValue.Text = "100.0";
        }


    //    ReportViewer1.LocalReport.Refresh();

    }

}