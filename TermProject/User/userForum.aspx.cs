using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.User
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        DataSet myDS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            showFile();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int temp = P2WS.addQuestion(Session["email"].ToString(), txtQuestion.Value, Convert.ToInt32(Session["verification"]));
            if (temp == 1)
            {
                lblMsg.Text = "Successfully submitted question. ";
            }
            else
            {
                lblMsg.Text = "Failed to submiited question. ";
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