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
            //lblMsg.Text = "";
            int rowIndex = e.RowIndex;
            Int64 capacity;
            TextBox Tbox;
            int accountID = Convert.ToInt32(gvManagement.Rows[rowIndex].Cells[0].Text);

            Tbox = (TextBox)gvManagement.Rows[rowIndex].Cells[3].Controls[0];
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
            else if (capacity < Convert.ToInt64(gvManagement.Rows[rowIndex].Cells[4].Text))
            {//StorageCapacity cannot be smaller than StorageUsed
                lblMsg.Text = "Cannot set Storage Capacity lower than current cloud Storage size. ";
                return;
            }
            else
            {
                P2WS.updateStorageCapacity(accountID, Int64.Parse(storageCapacity), Convert.ToInt32(Session["verification"]));
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

        protected void gvManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            int index = e.RowIndex;
            int fileID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);

            int flag = P2WS.deleteAccount(fileID, Convert.ToInt32(Session["verification"]));

            if (flag == 0)
                lblMsg.Text = "No rows were affected by this action. ";
            else if (flag == -1)
                lblMsg.Text = "An exception occured while performing this action. ";
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Delted all files and account information in regards to " +
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

                // Retrieve the row that contains the button 
                // from the Rows collection.
                //GridViewRow row = gvManagement.Rows[index];

                int userID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);

                // Add code here to add the item to the shopping cart.
                int flag = P2WS.resetPassord(userID, Convert.ToInt32(Session["verification"]));
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


    }
}