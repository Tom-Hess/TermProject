using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;
using System.Data;
using TermProject.RegistrationWS;

namespace TermProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        RegistrationWS.RegistrationWS RegWS = new RegistrationWS.RegistrationWS();
        int adminID = 1;
        double adminCapacity = 0;

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
            else if(!myValidation.IsValidEmail(txtEmail.Text))
            {
                lblMsg.Text = "Invalid email format.";
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
                lblMsg.Text = "Password must be the same. ";
            }
            else
            {
                //create the Admin in the Database, display message
                Person newAdmin = new Person();
                newAdmin.AccountType = adminID;
                newAdmin.Email = txtEmail.Text;
                newAdmin.Name = txtName.Text;
                newAdmin.StorageCapacity = adminCapacity;
                newAdmin.Password = txtPassword.Text;

                if (RegWS.AddAdmin(newAdmin))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Account successfully created.'); window.location='" +
                    Request.ApplicationPath + "adminLogin.aspx';", true);
                }
                else
                {
                    lblMsg.Text = "Email already in use!";
                }


            }
        }
    }
}