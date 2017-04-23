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
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();
        
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
            gvManagement.EditIndex = -1;
            showFiles();
        }

        protected void gvManagement_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvManagement.EditIndex = e.NewEditIndex;
            showFiles();
        }

        protected void gvManagement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Int64 capacity;
            TextBox Tbox;
            int accountID = Convert.ToInt32(gvManagement.Rows[rowIndex].Cells[0].Text);

            Tbox = (TextBox)gvManagement.Rows[rowIndex].Cells[4].Controls[0];
            string storageCapacity = Tbox.Text;

            if (myValidation.IsEmpty(storageCapacity))
            {
                lblMsg.Text = "Storage Capacity cannot be blank. ";
                return;
            }
            else if (!Int64.TryParse(storageCapacity, out capacity)) {
                lblMsg.Text = "Storage Capacity must be an integer. ";
                return;
            }
            else if (capacity < Convert.ToInt64(gvManagement.Rows[rowIndex].Cells[5].Text))
            {//StorageCapacity cannot be smaller than StorageUsed
                lblMsg.Text = "Cannot set Storage Capacity lower than current cloud Storage size. ";
                return;
            }
            else
            {
                int adminID = Convert.ToInt32(Session["AccountID"]);
                P2WS.updateStorageCapacity(accountID, adminID, Int64.Parse(storageCapacity), Convert.ToInt32(Session["verification"]));
            }
            gvManagement.EditIndex = -1;
            showFiles();
        }

        public void showFiles()
        {
            myDS = P2WS.getAllAccount(Convert.ToInt32(Session["Verification"]));
            gvManagement.DataSource = myDS;
            gvManagement.DataBind();
        }

        protected void gvManagement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblMsg.ForeColor = System.Drawing.Color.Red;
            if (e.CommandName == "ResetPassword")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.

                int userID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);

                int adminID = Convert.ToInt32(Session["AccountID"]);
                int flag = P2WS.resetPassord(userID, adminID, Convert.ToInt32(Session["verification"]));
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
            else if (e.CommandName == "activateORDeactiavate")
            {
                int adminID = Convert.ToInt32(Session["AccountID"]);
                int userID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);
                int accountType = Convert.ToInt32(gvManagement.Rows[index].Cells[2].Text);
                int rowsAffected = P2WS.activateOrDeactivate(userID, adminID, 
                    Convert.ToInt32(Session["verification"]));

                if (rowsAffected == 0)
                    lblMsg.Text = "No row was affected by this action. ";
                else if (rowsAffected == 1)
                    lblMsg.Text = "One row was affected by this action. ";
                else if (rowsAffected == -1)
                    lblMsg.Text = "Exception occured. ";
                else if (rowsAffected == 2 )
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    if (accountType == 0)
                        lblMsg.Text = "Account ID " + userID + " has been activated. ";
                    else
                        lblMsg.Text = "Account ID " + userID + " has been deactivated. ";
                    showFiles();
                }
            }
            else if (e.CommandName == "Delete")
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                int fileID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);

                int adminID = Convert.ToInt32(Session["AccountID"]);
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
        }

        protected void gvManagment_PageIndexChanging(Object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            // Set the GridView to display the correct page
            gvManagement.PageIndex = e.NewPageIndex;
            showFiles();
        }

        protected void gvManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}