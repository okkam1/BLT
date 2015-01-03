using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


public partial class Site : System.Web.UI.MasterPage {

    protected void Page_Load(object sender, EventArgs e)
    {

        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MainNav.Visible = true;
            userLabel.Visible = true;

            CountySeal.Height = 115;
        }

    }
}
