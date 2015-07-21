using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportPages_ClientFollowUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbStartDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            tbEndDate.Text = DateTime.Today.AddMonths(1).ToString("MM/dd/yyyy");
        }

        ClientFollowUpDataSet1.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        ClientFollowUpDataSet1.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;
    }

    protected void btnApplyDate_Click(object sender, EventArgs e)
    {
        ClientFollowUpDataSet1.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        ClientFollowUpDataSet1.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;

        ReportViewer1.LocalReport.Refresh();

    }
}