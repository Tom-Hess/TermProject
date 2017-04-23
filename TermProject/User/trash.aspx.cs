using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProject.Part2WS;
using TermProjectLibrary;

namespace TermProject.User
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DataSet myDS = new DataSet();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();
        Validation myValidation = new Validation();
        FileCloud cloud = new FileCloud();
        FileCloud trash = new FileCloud();
        FileData myFile = new FileData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) == 1)
            {
                Response.Redirect("~/Admin/management.aspx");
            }
            else if (Convert.ToInt32(Session["Login"]) == 0)
            {
            }
            else
            {
                Response.Redirect("~/LoginB/home.aspx");
            }

            if (!IsPostBack)
            {
                showFiles();
                if(gvFiles.Rows.Count == 0)
                    btnEmptyTrash.Visible = false;
            }
        }

        public void showFiles()
        {
            FileCloud cloud = (FileCloud)Session["trash"];
            ArrayList Files = new ArrayList(cloud.Files);
            gvFiles.DataSource = Files;
            gvFiles.DataBind();
        }

        protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //restore the file to the user's cloud
            int index = e.RowIndex;
            int fileID = Convert.ToInt32(gvFiles.Rows[index].Cells[1].Text);
            Int64 size = Convert.ToInt64(gvFiles.Rows[index].Cells[4].Text);

            trash = (FileCloud)Session["trash"];
            cloud = (FileCloud)Session["cloud"];

            for (int i = 0; i < trash.Files.Count; i++)
            {
                myFile = (FileData)trash.Files[i];

                if (myFile.FileID == fileID)
                {
                    cloud.Files.Add(myFile);
                    trash.Files.RemoveAt(i);
                    CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                            "Restored file from trash with ID #" + myFile.FileID, Convert.ToInt32(Session["verification"]));
                    break;
                }
            }
            Session["cloud"] = cloud;
            Session["trash"] = trash;

            //update user's storage used - ADD 
            P2WS.updateStorageUsed(Session["email"].ToString(), size, Convert.ToInt32(Session["verification"]));
            showFiles();
        }

        protected void btnEmptyTrash_Click(object sender, EventArgs e)
        {
            trash = (FileCloud)Session["trash"];
            int accountID = Convert.ToInt32(Session["accountID"]);

            foreach(FileData file in trash.Files)
            {
                int fileID = file.FileID;
                CloudWS.DeleteFile(fileID, Convert.ToInt32(Session["verification"]));
            }

            CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                            "Emptied their storage's trash bin", Convert.ToInt32(Session["verification"]));


            trash = new FileCloud();
            Session["trash"] = trash;

            showFiles();
            lblMsg.Text = "All files were deleted.";

        }
    }
}