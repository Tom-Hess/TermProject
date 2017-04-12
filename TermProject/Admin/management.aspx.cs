﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;

namespace TermProject.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) == 1)
            {
                if (!IsPostBack)
                {
                    //Load gridview
                }
            }
            else
            {
                Response.Redirect("~/LoginB/home.aspx");
            }

            
        }
    }
}