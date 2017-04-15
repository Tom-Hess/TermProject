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
            int fileID = Convert.ToInt32(gvManagement.Rows[rowIndex].Cells[0].Text);

            Tbox = (TextBox)gvManagement.Rows[rowIndex].Cells[3].Controls[0];
            string storageCapacity = Tbox.Text;

            if (myValidation.IsEmpty(storageCapacity))
            {
                lblMsg.Text = "Storage Capacity cannot be blank. ";
                return;
            }
            else if (!Int64.TryParse(storageCapacity, out capacity) {
                lblMsg.Text = "Storage Capacity must be an integer. ";
                return;
            }
            else if (capacity < Convert.ToInt64(gvManagement.Rows[rowIndex].Cells[4].Text))
            {//StorageCapacity cannot be smaller than StorageUsed
                lblMsg.Text = "Cannot set Storage Capacity lower than current cloud Storage size. ";
                return;
            }

            //update the file in the DB
            //P2WS.UpdateFile(fileID, fileName, Convert.ToInt32(Session["verification"]));

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
            int fileID = Convert.ToInt32(gvManagement.Rows[index].Cells[1].Text);
            Int64 size = -(Convert.ToInt64(gvManagement.Rows[index].Cells[4].Text));

            P2WS.DeleteFile(fileID, Convert.ToInt32(Session["verification"]));
            P2WS.updateStorageUsed(Session["email"].ToString(), size, Convert.ToInt32(Session["verification"]));
            showFiles();
        }

        protected void gvManagement_RowResetting(object sender, GridViewUpdateEventArgs e)
        {

        }


    }
}