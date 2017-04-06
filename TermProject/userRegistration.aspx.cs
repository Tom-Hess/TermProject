using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace TermProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (myValidation.IsEmpty(txtName.Text))
            {
                lblMsg.Text = "Name cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtEmail.Text))
            {
                lblMsg.Text = "Email cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtConfirm.Text))
            {
                lblMsg.Text = "Confirmation Password cannot be blank. ";
            }
            else if (txtPassword.Text != txtConfirm.Text)
            {
                lblMsg.Text = "Password and Confirmation Password must be the same. ";
            }
            else
            {
                //create the user in the Database, display message
            }
        }
    }
}