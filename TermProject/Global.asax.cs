using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TermProjectLibrary;

namespace TermProject
{
    public class Global : System.Web.HttpApplication
    {
        Serialize s = new Serialize();

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if(Session["Files"] != null)
            {
                // Write uploaded files to the DB using serialization
                object files = Session["Files"];
                string email = Session["Email"].ToString();


            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}