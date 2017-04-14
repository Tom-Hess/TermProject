using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace TermProject.User
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        DataSet myDS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) == 1)
            {
                Response.Redirect("~/Admin/management.aspx");
            }
            else if (Convert.ToInt32(Session["Login"]) == 0)
            {
            }
            else
            {
                Response.Redirect("~/LoginB/home.aspx");
            }
        }

        protected void btnViewFiles_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            DateTime temp;
            if (myValidation.IsEmpty(txtFrom.Text))
            {
                lblMsg.Text = "From field cannot be blank. ";
                txtFrom.Focus();
            }
            else if (!DateTime.TryParse(txtFrom.Text, out temp))
            {
                lblMsg.Text = "Invalid date format in From field. Put the date in the format mm/dd/yyyy";
                txtFrom.Focus();
            }
            else if (myValidation.IsEmpty(txtTo.Text))
            {
                lblMsg.Text = "To field cannot be blank. ";
                txtTo.Focus();
            }
            else if (!DateTime.TryParse(txtTo.Text, out temp))
            {
                lblMsg.Text = "Invalid date format in To field. Put the date in the format mm/dd/yyyy";
                txtTo.Focus();
            } else
            {
                DateTime fromTime = DateTime.Parse(txtFrom.Text);
                DateTime toTime = DateTime.Parse(txtTo.Text);
                string email = Session["Email"].ToString();

                myDS = P2WS.getUploadHistory(email, fromTime, toTime, 112358);
                gvFileHistory.DataSource = myDS;
                gvFileHistory.DataBind();
            }
        }
    }
}