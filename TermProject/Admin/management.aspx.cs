using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;
using System.Data;

namespace TermProject.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataSet myDS = new DataSet();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        Validation myValidation = new Validation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) == 1)
            {
                if (!IsPostBack)
                {
                    showFiles();
                }
            }
            else
            {
                Response.Redirect("~/LoginB/home.aspx");
            }
        }

        protected void gvManagement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvManagement_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvManagement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        public void showFiles()
        {
            myDS = P2WS.getAllAccount(Convert.ToInt32(Session["Verification"]));
            gvManagement.DataSource = myDS;
            gvManagement.DataBind();
        }

        protected void gvManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvManagement_RowResetting(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}