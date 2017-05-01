using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using TermProjectLibrary;

namespace TermProject
{
    public partial class accountSetting : System.Web.UI.UserControl
    {
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        Validation myValidation = new Validation();

        RegistrationWS.RegistrationWS RegWS = new RegistrationWS.RegistrationWS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Category("Misc")]
        public Part2WS.Person accountInfo { get; set; }

        public void btnChangePW_Click(object sender, EventArgs e)
        {
            dvEditInfo.Visible = false;
            dvChangePW.Visible = true;
        }

        public void btnChangeAccountInfo_Click(object sender, EventArgs e)
        {
            dvEditInfo.Visible = true;
            dvChangePW.Visible = false;
            txtName.Text = accountInfo.Name;
            txtEmail.Text = accountInfo.Email;
        }

        public void btnUpdatePW_Click(object sender, EventArgs e)
        {
            if (ValidateUpdatePW())
            {
                ArrayList myAL = new ArrayList(RegWS.ValidateLogin(accountInfo.Email, txtCurrentPW.Text));
                if (Convert.ToInt32(myAL[0]) == 0)
                {
                    lblUpdatePWError.Text = "Current password is invalid.";
                    txtCurrentPW.Focus();
                }
                else
                {
                    //update the password in the database
                    accountInfo.Password = txtNewPW.Text;
                    if (P2WS.updatePassword(accountInfo.Email, txtNewPW.Text, 
                        Convert.ToInt32(Session["verification"])) == 1)
                    {
                        lblUpdatePWError.Text = "Password successfully updated.";
                        lblUpdatePWError.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblUpdatePWError.Text = "Fail to update password";
                        lblUpdatePWError.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        public void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            lblUpdateInfoError.ForeColor = System.Drawing.Color.Red;
            if (validateUpdateInfo())
            {
                string oldEmail = Session["Email"].ToString();
                accountInfo.Email = txtEmail.Text;
                accountInfo.Name = txtName.Text;
                if (P2WS.UpdateAccount(accountInfo, oldEmail, Convert.ToInt32(Session["verification"])))
                {
                    Session["Email"] = accountInfo.Email;
                    lblUpdateInfoError.Text = "Successfully updated account information.";
                    lblUpdateInfoError.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblUpdateInfoError.Text = "New email already in use!";
                    txtEmail.Focus();
                }
            }
        }

        public bool ValidateUpdatePW()
        {
            lblUpdatePWError.ForeColor = System.Drawing.Color.Red;
            if (myValidation.IsEmpty(txtCurrentPW.Text))
            {
                lblUpdatePWError.Text = "Current password cannot be blank!";
                txtCurrentPW.Focus();
                return false;
            }
            if (myValidation.IsEmpty(txtNewPW.Text))
            {
                lblUpdatePWError.Text = "New password cannot be blank!";
                txtNewPW.Focus();
                return false;
            }
            if (myValidation.IsEmpty(txtConfirm.Text))
            {
                lblUpdatePWError.Text = "Please confirm your password.";
                txtConfirm.Focus();
                return false;
            }

            if (txtConfirm.Text != txtNewPW.Text)
            {
                lblUpdatePWError.Text = "Passwords do not match.";
                txtNewPW.Focus();
                return false;
            }

            if (txtCurrentPW.Text == txtNewPW.Text)
            {
                lblUpdatePWError.Text = "New password cannot be the same as old password. ";
                txtNewPW.Focus();
                return false;
            }

            return true;
        }
        public bool validateUpdateInfo()
        {
            lblUpdateInfoError.ForeColor = System.Drawing.Color.Red;
            if (myValidation.IsEmpty(txtEmail.Text))
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
            if (myValidation.IsEmpty(txtName.Text))
            {
                lblUpdateInfoError.Text = "Name cannot be blank.";
                txtName.Focus();
                return false;
            }
            return true;
        }
    }
}