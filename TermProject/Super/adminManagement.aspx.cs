using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;
using System.Data;

namespace TermProject.Super
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DataSet myDS = new DataSet();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        Validation myValidation = new Validation();
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 3)
            {
                Response.Redirect("../logout.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    showFiles();
                }
            }

        }

        //protected void gvManagement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //}

        //protected void gvManagement_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //}

        //protected void gvManagement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
            
        //}

        public void showFiles()
        {
            myDS = P2WS.getAllAdmin(Convert.ToInt32(Session["Verification"]));
            gvManagement.DataSource = myDS;
            gvManagement.DataBind();
        }

        protected void gvManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            int index = e.RowIndex;
            int fileID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);
            int adminID = Convert.ToInt32(Session["AccountID"]); 
            //This line really doesn't do anything. Super's action won't be recorded.

            //Delete the account and all of its cloud data
            int flag = CloudWS.deleteAccount(fileID, adminID, Convert.ToInt32(Session["verification"]));
            
            if (flag == 0)
                lblMsg.Text = "No rows were affected by this action. ";
            else if (flag == -1)
                lblMsg.Text = "An exception occured while performing this action. ";
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Deleted all files and account information in regards to " +
                    gvManagement.Rows[index].Cells[1].Text + ". ";
            }
            showFiles();
        }

        protected void gvManagement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            if (e.CommandName == "ResetPassword")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                int userID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);
                
                int flag = P2WS.resetPassord(userID, Convert.ToInt32(Session["AccountID"]), Convert.ToInt32(Session["verification"]));
                //The middle parameter doesn't do anything. Super's action won't be recorded.
                if (flag == 0)
                {
                    lblMsg.Text = "Unable to locate this account. ";
                }
                else if (flag == -1)
                {
                    lblMsg.Text = "Exception occured. ";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Account " + userID.ToString() +
                        "'s password has been resetted to the default password. ";
                }
            }
        }

        protected void gvManagment_PageIndexChanging(Object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            // Set the GridView to display the correct page
            gvManagement.PageIndex = e.NewPageIndex;
            showFiles();
        }

        protected void gvManagement_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
    }
}