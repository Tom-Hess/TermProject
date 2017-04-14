using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace TermProject.User
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        Part2WS.Person accountInfo = new Part2WS.Person();
        Validation myValidation = new Validation();

        RegistrationWS.RegistrationWS RegWS = new RegistrationWS.RegistrationWS();
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
            //create person object for the user's current information
            accountInfo = P2WS.GetAccountInfo(Session["Email"].ToString(), 112358);
        }

        protected void btnChangePW_Click(object sender, EventArgs e)
        {
            dvEditInfo.Visible = false;
            dvChangePW.Visible = true;
        }

        protected void btnChangeAccountInfo_Click(object sender, EventArgs e)
        {
            dvEditInfo.Visible = true;
            dvChangePW.Visible = false;
            txtName.Text = accountInfo.Name;
            txtEmail.Text = accountInfo.Email;

        }

        protected void btnUpdatePW_Click(object sender, EventArgs e)
        {
            if(ValidateUpdatePW())
            {
                ArrayList myAL = new ArrayList(RegWS.ValidateLogin(accountInfo.Email, txtCurrentPW.Text));
                if (Convert.ToInt32(myAL[0]) == 0)
                {
                    lblUpdatePWError.Text = "Current Password is invalid.";
                    txtCurrentPW.Focus();
                }else
                {
                    //update the password in the database
                    accountInfo.Password = txtNewPW.Text;
                    P2WS.UpdateAccount(accountInfo, accountInfo.Email, 112358);
                    lblUpdatePWError.Text = "Password successfully updated.";
                    lblUpdatePWError.ForeColor = System.Drawing.Color.Green;
                }
            }
            
        }

        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if(validateUpdateInfo())
            {
                string oldEmail = Session["Email"].ToString();
                accountInfo.Email = txtEmail.Text;
                accountInfo.Name = txtName.Text;
                P2WS.UpdateAccount(accountInfo, oldEmail, 112358);

                Session["Email"] = accountInfo.Email;
                lblUpdateInfoError.Text = "Successfully updated account information.";
                lblUpdateInfoError.ForeColor = System.Drawing.Color.Green;
            }
            
        }

        public bool ValidateUpdatePW()
        {
            lblUpdatePWError.ForeColor = System.Drawing.Color.Red;
            if(myValidation.IsEmpty(txtCurrentPW.Text))
            {
                lblUpdatePWError.Text = "Current password cannot be blank!";
                txtCurrentPW.Focus();
                return false;
            }
            if(myValidation.IsEmpty(txtNewPW.Text))
            {
                lblUpdatePWError.Text = "New password cannot be blank!";
                txtNewPW.Focus();
                return false;
            }
            if(myValidation.IsEmpty(txtConfirm.Text))
            {
                lblUpdatePWError.Text = "Please confirm your password.";
                txtConfirm.Focus();
                return false;
            }

            if(txtConfirm.Text != txtNewPW.Text)
            {
                lblUpdatePWError.Text = "Passwords do not match.";
                txtNewPW.Focus();
                return false;
            }

            return true;
        }
        public bool validateUpdateInfo()
        {
            lblUpdateInfoError.ForeColor = System.Drawing.Color.Red;
            if(myValidation.IsEmpty(txtEmail.Text))
            {
                lblUpdateInfoError.Text = "Email cannot be blank.";
                txtEmail.Focus();
                return false;
            }
            if (!myValidation.IsValidEmail(txtEmail.Text))
            {
                lblUpdateInfoError.Text = "Invalid email.";
                txtEmail.Focus();
                return false;
            }
            if(myValidation.IsEmpty(txtName.Text))
            {
                lblUpdateInfoError.Text = "Name cannot be blank.";
                txtName.Focus();
                return false;
            }
            return true;
        }
    }
}