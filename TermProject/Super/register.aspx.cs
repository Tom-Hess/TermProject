using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;

namespace TermProject.Super
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        RegistrationWS.RegistrationWS RegWS = new RegistrationWS.RegistrationWS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 2)
            {
                Response.Redirect("../logout.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (myValidation.IsEmpty(txtName.Text))
            {
                lblMsg.Text = "Name cannot be blank. ";
                txtName.Focus();
            }
            else if (myValidation.IsEmpty(txtEmail.Text))
            {
                lblMsg.Text = "Email cannot be blank. ";
                txtEmail.Focus();
            }
            else if (!myValidation.IsValidEmail(txtEmail.Text))
            {
                lblMsg.Text = "Not a valid email address. ";
                txtEmail.Focus();
            }
            else if (myValidation.IsEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password cannot be blank. ";
                txtPassword.Focus();
            }
            else if (myValidation.IsEmpty(txtConfirm.Text))
            {
                lblMsg.Text = "Confirmation Password cannot be blank. ";
                txtConfirm.Focus();
            }
            else if (txtPassword.Text != txtConfirm.Text)
            {
                lblMsg.Text = "Password and Confirmation Password must be the same. ";
                txtPassword.Focus();
            }
            else
            {
                createAdmin();
            }
        }

        public void createAdmin()
        {
            RegistrationWS.Person newPerson = new RegistrationWS.Person();
            newPerson.AccountType = 1;
            newPerson.Email = txtEmail.Text;
            newPerson.Name = txtName.Text;
            newPerson.StorageSpace = 0;
            newPerson.Password = txtPassword.Text;

            if (RegWS.AddAccount(newPerson))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "alert('Admin successfully created.');window.location ='adminManagement.aspx';", true);
            }
            else
            {
                lblMsg.Text = "Email already in use!";
            }
        }
    }
}