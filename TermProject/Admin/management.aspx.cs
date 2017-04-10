using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) == 1)
            {
            }
            else if (Convert.ToInt32(Session["Login"]) == 0)
            {
                Response.Redirect("~/User/cloud.aspx");
            }
            else
            {
                Response.Redirect("~/LoginB/home.aspx");
            }
        }
    }
}