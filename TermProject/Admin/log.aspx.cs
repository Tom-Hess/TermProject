using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;
using System.Data;

namespace TermProject.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        DataSet myDS = new DataSet();
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

        protected void btnFind_Click(object sender, EventArgs e)
        {
            DateTime begin, end;
            if (myValidation.IsEmpty(txtEmail.Text)) {
                lblMsg.Text = "Email cannot be blank. ";
                txtEmail.Focus();
            }
            else if (!myValidation.IsValidEmail(txtEmail.Text))
            {
                lblMsg.Text = "Not a valid email address. ";
                txtEmail.Focus();
            }
            else if (myValidation.IsEmpty(txtFrom.Text))
            {
                lblMsg.Text = "From field cannot be blank. ";
                txtFrom.Focus();
            }
            else if (!DateTime.TryParse(txtFrom.Text, out begin))
            {
                lblMsg.Text = "Invalid date format in From field. Put date in the format mm/dd/yyyy";
                txtFrom.Focus();
            }
            else if (myValidation.IsEmpty(txtTo.Text))
            {
                lblMsg.Text = "To field cannot be blank. ";
                txtTo.Focus();
            }
            else if (!DateTime.TryParse(txtTo.Text, out end))
            {
                lblMsg.Text = "Invalid date format in To field. Put date in the format mm/dd/yyyy";
                txtTo.Focus();
            }
            else if (begin > end)
            {
                lblMsg.Text = "From date cannot be later than To date. ";
                txtFrom.Focus();
            }
            else
            {
                //passed all validation. Show the transactions in the gridview.
                string email = txtEmail.Text;

                myDS = P2WS.getUploadHistory(email, begin, end, Convert.ToInt32(Session["verification"]));
                gvTransactionLog.DataSource = myDS;
                gvTransactionLog.DataBind();
            }
            
        }
    }
}