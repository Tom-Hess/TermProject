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
            int index = e.RowIndex;
            int fileID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);
            //Int64 size = -(Convert.ToInt64(gvManagement.Rows[index].Cells[4].Text));
            //Don't need to update the account's size. It is deleted

            int flag = P2WS.deleteAccount(fileID, Convert.ToInt32(Session["verification"]));
            //Delete transaction and account at the same time

            if (flag == 0)
                lblMsg.Text = "No rows were affected by this action. ";
            else if (flag == -1)
                lblMsg.Text = "An exception occured while perform this action. ";
            else
            {
                lblMsg.Text = "Delted all files and account information in regard to " +
                    gvManagement.Rows[index].Cells[1].Text + ". ";
                //P2WS.updateStorageUsed(Session["email"].ToString(), size, Convert.ToInt32(Session["verification"]));
            }
            showFiles();
        }

        protected void gvManagement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ResetPassword")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                //GridViewRow row = gvManagement.Rows[index];

                int fileID = Convert.ToInt32(gvManagement.Rows[index].Cells[0].Text);

                // Add code here to add the item to the shopping cart.
                int flag = P2WS.resetPassord(fileID, Convert.ToInt32(Session["verification"]));
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
                    lblMsg.Text = "Account " + fileID.ToString() +
                        "'s password has been resetted to default password. ";
                }
            }
        }


    }
}