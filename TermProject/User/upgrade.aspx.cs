using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.User
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit(object sender, EventArgs e)
        {
            string temp = Request.Form["option"];

            if (temp == "Option 1")
            {
                Session["upgradeOption"] = 1;
            }
            else if (temp == "Option 2")
            {
                Session["upgradeOption"] = 2;
            }
            else if (temp == "Option 3")
            {
                Session["upgradeOption"] = 3;
            }
            else
            {

            }
        }
    }
}