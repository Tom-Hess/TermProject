using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;

namespace TermProject.LoginB
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        RegistrationWS.RegistrationWS RegWS = new RegistrationWS.RegistrationWS();
        Int64 userCapacity = 10000000;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                createUser();
            }
        }

        public void createUser()
        {
            HttpCookie myUserCookie = new HttpCookie("UserCookie");

            //create the Admin in the Database, display message
            RegistrationWS.Person newPerson = new RegistrationWS.Person();
            newPerson.AccountType = 0;
            newPerson.Email = txtEmail.Text;
            newPerson.Name = txtName.Text;
            newPerson.StorageSpace = userCapacity;
            newPerson.Password = txtPassword.Text;

            if (RegWS.AddAccount(newPerson))
            {
                if (chkRemember.Checked)
                {
                    myUserCookie.Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    myUserCookie.Expires = DateTime.Now.AddDays(-1);

                }
                myUserCookie.Values["UserName"] = txtEmail.Text;
                myUserCookie.Values["Password"] = txtPassword.Text;
                Response.Cookies.Add(myUserCookie);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Account successfully created.');window.location ='login.aspx';", true);
            }
            else
            {
                lblMsg.Text = "Email already in use!";
            }
        }
    }
}