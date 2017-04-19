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
        Serialize mySerialization = new Serialize();

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
            if(Session["cloud"] != null)
            {
                // Write uploaded files to the DB using serialization
                object files = Session["cloud"];
                int accountID = Convert.ToInt32(Session["accountID"]);
                mySerialization.writeCloud(files, accountID);
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}