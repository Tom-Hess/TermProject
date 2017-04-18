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
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();

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
                int accountID = Convert.ToInt32(Session["accountID"]);
                CloudWS.writeCloud(files, accountID);
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}