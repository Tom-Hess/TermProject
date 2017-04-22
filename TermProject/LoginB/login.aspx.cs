using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;

namespace TermProject.LoginB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();
        RegistrationWS.RegistrationWS RegWS = new RegistrationWS.RegistrationWS();
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();
        PWEncryption myEncryption = new PWEncryption();
        Serialize mySerialization = new Serialize();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userLogin = Request.Cookies["UserCookie"];

            if (!IsPostBack)
            {
                //if a cookie has been created, load the user's login information into the textboxes
                if (Request.Cookies["UserCookie"] != null)
                {
                    try
                    {
                        txtEmail.Text = userLogin["UserName"].ToString();
                        string pw = myEncryption.DecryptString(userLogin["Password"]);
                        txtPassword.Attributes["value"] = pw;
                        chkRemember.Checked = true;
                    } catch (Exception ex)
                    {
                        userLogin.Expires = DateTime.Now.AddDays(-1);
                    }

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie myUserCookie = new HttpCookie("UserCookie");
            if (myValidation.IsEmpty(txtEmail.Text))
            {
                lblMsg.Text = "Email cannot be blank. ";
                txtEmail.Focus();
            }
            else if (myValidation.IsEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password cannot be blank. ";
                txtPassword.Focus();
            }
            else
            {
                //Check Database for the entered username and login
                ArrayList loginArray = new ArrayList(RegWS.ValidateLogin(txtEmail.Text, txtPassword.Text));
                int count = Convert.ToInt32(loginArray[0]);
                if(count > 0 )
                {
                    //If found and chkRemember is checked, create a cookie containing user + pw info, then redirect to the next page
                    if (chkRemember.Checked)
                    {
                        myUserCookie.Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        myUserCookie.Expires = DateTime.Now.AddDays(-1);

                    }
                    myUserCookie.Values["UserName"] = txtEmail.Text;
                    //encrypt PW
                    string pw = txtPassword.Text;
                    pw = myEncryption.EncryptString(pw);

                    myUserCookie.Values["Password"] = pw;
                    Response.Cookies.Add(myUserCookie);

                    int accountType = Convert.ToInt32(loginArray[1]);
                    int accountID = Convert.ToInt32(loginArray[2]);
                    Session["AccountID"] = accountID;
                    Session["verification"] = 112358;

                    FileCloud cloud = new FileCloud();
                    FileCloud trash = new FileCloud();

                    if (mySerialization.checkCloudExists(accountID))
                    {
                        if (mySerialization.getFileCloud(accountID) != null) 
                        {
                            cloud = (FileCloud)(mySerialization.getFileCloud(accountID));
                            trash = (FileCloud)(mySerialization.getFileCloudTrash(accountID));
                        }
                    }
                    else  
                    {
                        mySerialization.createCloud(accountID);
                    }

                    Session["trash"] = trash;
                    Session["cloud"] = cloud;

                    switch (accountType)
                    {
                        case 1:
                            //Admin
                            Session["Login"] = 1;
                            Session["Email"] = txtEmail.Text;
                            Response.Redirect("~/Admin/management.aspx");
                            break;
                        case 2:
                            // SUPER admin
                            Session["Login"] = 2;
                            Session["Email"] = txtEmail.Text;
                            Response.Redirect("~/Super/adminManagement.aspx");
                            break;
                        default:
                            // User
                            Session["Login"] = 0;
                            Session["Email"] = txtEmail.Text;
                            Response.Redirect("~/User/cloud.aspx");
                            break;
                    }

                }else
                {
                    lblMsg.Text = "Invalid login credentials.";
                    txtPassword.Text = "";
                    myUserCookie.Expires = DateTime.Now.AddDays(-1);
                }

            }
        }
    }
}