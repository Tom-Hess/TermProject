using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();

        protected void Page_Load(object sender, EventArgs e)
        {
            forum.DataBind();

            string question = Request["question"];
            string ID = Request["id"];

            int temp = P2WS.addAnswer(Session["email"].ToString(), question, Convert.ToInt32(ID),
                Convert.ToInt32(Session["verification"]));

        }
    }
}