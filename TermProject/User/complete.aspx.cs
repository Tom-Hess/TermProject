using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.User
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 1)
            {
                Response.Redirect("../logout.aspx");
            }
            else if (!IsPostBack)
            {
                string email = Session["email"].ToString();
                Int32 upgradeCapacity = Int32.Parse(Session["option"].ToString());
                int temp = P2WS.updateStorage(email, upgradeCapacity, Convert.ToInt32(Session["verifiction"].ToString()));
            }

        }
    }
}