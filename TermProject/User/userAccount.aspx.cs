using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace TermProject.User
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        Part2WS.Person accountInfo = new Part2WS.Person();
        Validation myValidation = new Validation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 1)
            {
                Response.Redirect("../logout.aspx");
            }

            //create person object for the user's current information
            accountInfo = P2WS.GetAccountInfo(Session["Email"].ToString(),
                Convert.ToInt32(Session["verification"]));

            accountSetting.accountInfo = accountInfo;

        }
    }
}