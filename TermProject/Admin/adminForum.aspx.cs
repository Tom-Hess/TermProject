using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        DataSet myDS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            showFile();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int temp = P2WS.addAnswer(Session["email"].ToString(), txtAnswer.Value, int.Parse(txtID.Value), Convert.ToInt32(Session["verification"]));
            if (temp == 1)
            {
                lblMsg.Text = "Successfully submitted answer. ";
            }
            else
            {
                lblMsg.Text = "Failed to submited answer. ";
            }
            showFile();
        }

        public void showFile()
        {
            myDS = P2WS.getForum(Convert.ToInt32(Session["Verification"]));
            forum.DataBind();
        }
    }
}