using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace TermProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Validation myValidation = new Validation();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie adminLogin = Request.Cookies["AdminCookie"];
            if (!IsPostBack)
            {
                //if a cookie has been created, load the user's login information into the textboxes
                if (Request.Cookies["AdminCookie"] != null)
                {
                    txtName.Text = adminLogin["UserName"].ToString();
                    txtPassword.Attributes["value"] = adminLogin["Password"].ToString();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie myAdminLogin = new HttpCookie("AdminCookie");
            if (myValidation.IsEmpty(txtName.Text))
            {
                lblMsg.Text = "Name cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password cannot be blank. ";
            }
            else
            {
                //Check Database for the entered username and login

                //If found and chkRemember is checked, create a cookie containing user + pw info, then redirect to the next page
                if (chkRemember.Checked)
                {
                   myAdminLogin.Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    myAdminLogin.Expires = DateTime.Now.AddDays(-1);

                }
                myAdminLogin.Values["UserName"] = txtName.Text;
                myAdminLogin.Values["Password"] = txtPassword.Text;
                Response.Cookies.Add(myAdminLogin);
            }
        }
    }
}