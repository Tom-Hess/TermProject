using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.User
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();

        protected void Page_Load(object sender, EventArgs e)
        {
            string question = Request["question"];

            int temp = P2WS.addQuestion(Session["email"].ToString(), question,
                Convert.ToInt32(Session["verification"]));
        }
    }
}