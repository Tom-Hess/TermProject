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
                if (rblRole.SelectedValue == "Administrator")
                {
                    //create the Admin in the Database, display message
                    //Person newAdmin = new Person();
                    RegistrationWS.Person newAdmin = new RegistrationWS.Person();
                    newAdmin.AccountType = adminID;
                    newAdmin.Email = txtEmail.Text;
                    newAdmin.Name = txtName.Text;
                    newAdmin.StorageCapacity = adminCapacity;
                    newAdmin.Password = txtPassword.Text;

                    if (RegWS.AddAdmin(newAdmin))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Administrator account successfully created.'); window.location='" +
                        Request.ApplicationPath + "../Admin/management.aspx';", true);
                    }
                    else
                    {
                        lblMsg.Text = "Email already in use!";
                    }
                }
                else
                {
                    //create the user in the Database, display message
                    //Person newUser = new Person();
                    RegistrationWS.Person newUser = new RegistrationWS.Person();

                    newUser.AccountType = adminID;
                    newUser.Email = txtEmail.Text;
                    newUser.Name = txtName.Text;
                    newUser.StorageCapacity = adminCapacity;
                    newUser.Password = txtPassword.Text;

                    if (RegWS.AddAdmin(newUser))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('User account successfully created.'); window.location='" +
                        Request.ApplicationPath + "../User/cloud.aspx';", true);
                    }
                    else
                    {
                        lblMsg.Text = "Email already in use!";
                    }
                }
            }
        }
    }
}