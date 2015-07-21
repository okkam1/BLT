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
    String MaxLeadValue = "100.0";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            tbMinLeadValue.Text = MinLeadValue; 
            tbMaxLeadValue.Text = MaxLeadValue; 
        }

        ClientsByBloodLeadLevelDataSet1.SelectParameters["Min_Lead_Value"].DefaultValue = MinLeadValue;
        ClientsByBloodLeadLevelDataSet1.SelectParameters["Max_Lead_Value"].DefaultValue = MaxLeadValue;
    }

    protected void btnApplyLeadValueFilter_Click(object sender, EventArgs e)
    {
        if (tbMinLeadValue.Text != "")
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Min_Lead_Value"].DefaultValue = tbMinLeadValue.Text;
        else
        {
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Min_Lead_Value"].DefaultValue = MinLeadValue;
            tbMinLeadValue.Text = MinLeadValue;
        }
        if (tbMaxLeadValue.Text != "")
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Max_Lead_Value"].DefaultValue = tbMaxLeadValue.Text;
        else
        {
            ClientsByBloodLeadLevelDataSet1.SelectParameters["Max_Lead_Value"].DefaultValue = "100.0";
            tbMaxLeadValue.Text = MaxLeadValue;
        }


        ReportViewer1.LocalReport.Refresh();

    }

}