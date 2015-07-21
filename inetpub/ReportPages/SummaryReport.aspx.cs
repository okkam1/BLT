using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportPages_SummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbEndDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            tbStartDate.Text = DateTime.Today.AddMonths(-1).ToString("MM/dd/yyyy");
        }

        SummaryReportDataSet1.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        SummaryReportDataSet1.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;
    }

    protected void btnApplyDate_Click(object sender, EventArgs e)
    {
        SummaryReportDataSet1.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        SummaryReportDataSet1.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;

        ReportViewer1.LocalReport.Refresh();

    }
}