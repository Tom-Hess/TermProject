using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class forum : System.Web.UI.UserControl
    {
        DataSet myDS = new DataSet();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void DataBind()
        {
            myDS = P2WS.getForum(Convert.ToInt32(Session["Verification"]));
            if (myDS.Tables[0].Rows.Count == 0)
            {
                lblMsg.Text = "Currently there is no question from user. ";
            }
            else
            {
                gvForum.DataSource = myDS;
                gvForum.DataBind();
            }
        }

        protected void gvForum_PageIndexChanging(Object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            // Set the GridView to display the correct page
            gvForum.PageIndex = e.NewPageIndex;
            DataBind();
        }
    }
}