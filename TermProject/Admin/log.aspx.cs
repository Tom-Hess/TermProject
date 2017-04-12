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
            }
            else if (myValidation.IsValidEmail(txtEmail.Text))
            {
                lblMsg.Text = "Not a valid email address. ";
            }
            else if (myValidation.IsEmpty(txtFrom.Text))
            {
                lblMsg.Text = "From field cannot be blanlk. ";
            }
            else if (!DateTime.TryParse(lblFrom.Text, out temp))
            {
                lblMsg.Text = "Invalid date format in From field. mm/dd/yyyy";
            }
            else if (myValidation.IsEmpty(txtTo.Text))
            {
                lblMsg.Text = "To field cannot be blank. ";
            }
            else if (!DateTime.TryParse(lblTo.Text, out temp))
            {
                lblMsg.Text = "Invalid date format in To field. Validate format: mm/dd/yyyy";
            }
            else
            {
                //pass all validation. Update account
            }
            
        }
    }
}