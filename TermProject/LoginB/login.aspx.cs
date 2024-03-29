﻿using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userLogin = Request.Cookies["UserCookie"];

            if (!IsPostBack)
            {
                //if a cookie has been created, load the user's login information into the textboxes
                if (Request.Cookies["UserCookie"] != null)
                {
                    txtEmail.Text = userLogin["UserName"].ToString();
                    txtPassword.Attributes["value"] = userLogin["Password"].ToString();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie myUserCookie = new HttpCookie("UserCookie");
            if (myValidation.IsEmpty(txtEmail.Text))
            {
                lblMsg.Text = "Email cannot be blank. ";
            }
            else if (myValidation.IsEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password cannot be blank. ";
            }
            else
            {
                //Check Database for the entered username and login
                ArrayList loginArray = new ArrayList(RegWS.ValidateLogin(txtEmail.Text, txtPassword.Text));
                int count = Convert.ToInt32(loginArray[0]);
                if(count > 0 )
                {
                    Session["Login"] = 1;
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
                    myUserCookie.Values["Password"] = txtPassword.Text;
                    Response.Cookies.Add(myUserCookie);

                    int accountID = Convert.ToInt32(loginArray[1]);
                    if(accountID ==1)
                    {
                        Response.Redirect("~/Admin/management.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/User/cloud.aspx");
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