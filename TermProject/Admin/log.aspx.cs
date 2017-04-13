using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;

namespace TermProject.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();

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
            DateTime temp;
            if (myValidation.IsEmpty(txtEmail.Text)) {
                lblMsg.Text = "Email cannot be blank. ";
                txtEmail.Focus();
            }
            else if (myValidation.IsValidEmail(txtEmail.Text))
            {
                lblMsg.Text = "Not a valid email address. ";
                txtEmail.Focus();
            }
            else if (myValidation.IsEmpty(txtFrom.Text))
            {
                lblMsg.Text = "From field cannot be blank. ";
                txtFrom.Focus();
            }
            else if (!DateTime.TryParse(lblFrom.Text, out temp))
            {
                lblMsg.Text = "Invalid date format in From field in the format mm/dd/yyyy";
                txtFrom.Focus();
            }
            else if (myValidation.IsEmpty(txtTo.Text))
            {
                lblMsg.Text = "To field cannot be blank. ";
                txtTo.Focus();
            }
            else if (!DateTime.TryParse(txtTo.Text, out temp))
            {
                lblMsg.Text = "Invalid date format in To field. Validate format: mm/dd/yyyy";
                txtTo.Focus();
            }
            else
            {
                //passed all validation. Show the transactions in the gridview.

            }
            
        }
    }
}