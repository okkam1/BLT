﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportPages_ListOfFamilies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnApplyDate_Click(object sender, EventArgs e)
    {
        SqlDataSourcePerson.SelectParameters["StartDate"].DefaultValue = tbStartDate.Text;
        SqlDataSourcePerson.SelectParameters["EndDate"].DefaultValue = tbEndDate.Text;

        //SqlDataSourcePerson.SelectCommand.
    }
}