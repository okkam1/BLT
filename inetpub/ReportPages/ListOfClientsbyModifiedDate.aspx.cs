using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class ReportPages_ListOfClientsByModifiedDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbEndDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            tbStartDate.Text = DateTime.Today.AddMonths(-1).ToString("MM/dd/yyyy");
        }

        SqlDataSourcePerson.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        SqlDataSourcePerson.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;
    }

    protected void btnApplyDate_Click(object sender, EventArgs e)
    {
        SqlDataSourcePerson.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        SqlDataSourcePerson.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;

        ReportViewer1.LocalReport.Refresh();

    }
}