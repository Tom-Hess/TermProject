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
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataSet myDS = new DataSet();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();
        Validation myValidation = new Validation();
        FileCloud cloud = new FileCloud();
        FileCloud trash = new FileCloud();
        FileData myFile = new FileData();
        Serialize mySerialization = new Serialize();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 1)
            {
                Response.Redirect("../logout.aspx");
            }else
            {
                if(!IsPostBack)
                {
                    showFiles();
                }
            }

        }

        protected void gvFiles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFiles.EditIndex = -1;
            showFiles();
        }

        protected void gvFiles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFiles.EditIndex = e.NewEditIndex;
            showFiles();
        }

        protected void gvFiles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMsg.Text = "";
            int rowIndex = e.RowIndex;
            TextBox Tbox;
            int fileID = Convert.ToInt32(gvFiles.Rows[rowIndex].Cells[1].Text);

            Tbox = (TextBox)gvFiles.Rows[rowIndex].Cells[2].Controls[0];
            string fileName = Tbox.Text;

            if (myValidation.IsEmpty(fileName))
            {
                lblMsg.Text = "Invalid file name";
            }else
            {
                //update the file name in the arraylist
                cloud = (FileCloud)Session["cloud"];

                for (int i = 0; i<cloud.Files.Count; i++)
                {
                    myFile = (FileData)cloud.Files[i];

                    if (myFile.FileID == fileID)
                    {
                        myFile.Title = fileName;
                        CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]), 
                            "Renamed file #" + myFile.FileID + " to " + fileName, Convert.ToInt32(Session["verification"]));
                        break;
                    }
                }
                gvFiles.EditIndex = -1;
                showFiles();
            }
        }


        public void showFiles()
        {
            FileCloud cloud = (FileCloud)Session["cloud"];
            ArrayList Files = new ArrayList(cloud.Files);
            gvFiles.DataSource = Files;
            gvFiles.DataBind();
            if (gvFiles.Rows.Count > 0)
                btnDeleteAll.Visible = true;
            else
                btnDeleteAll.Visible = false;
        }

        protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int fileID = Convert.ToInt32(gvFiles.Rows[index].Cells[1].Text);
            Int64 size = -(Convert.ToInt64(gvFiles.Rows[index].Cells[4].Text));
            CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]), "Deleted file with ID #" + fileID, Convert.ToInt32(Session["verification"]));

            cloud = (FileCloud)Session["cloud"];
            trash = (FileCloud)Session["trash"];
            for (int i = 0; i < cloud.Files.Count; i++)
            {
                myFile = (FileData)cloud.Files[i];

                if (myFile.FileID == fileID)
                {
                    cloud.Files.RemoveAt(i);
                    trash.Files.Add(myFile);
                    break;
                }
            }
            Session["cloud"] = cloud;
            Session["trash"] = trash;

            P2WS.updateStorageUsed(Session["email"].ToString(), size, Convert.ToInt32(Session["verification"]));
            showFiles();
        }

        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Download LinkButton is clicked
            if(e.CommandName == "Download")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string fileName = gvFiles.Rows[rowIndex].Cells[2].Text;
                int fileID = Convert.ToInt32(gvFiles.Rows[rowIndex].Cells[1].Text);

                Int64 fileSize = Convert.ToInt64(gvFiles.Rows[rowIndex].Cells[4].Text);


                cloud = (FileCloud)Session["cloud"];

                for(int i = 0; i < cloud.Files.Count; i++)
                {
                    myFile = (FileData)cloud.Files[i];

                    if (myFile.FileID == fileID)
                        break;
                }

                byte[] fileDataBytes = new byte[fileSize];

                //get file's data from download DB
                fileDataBytes = CloudWS.getDownloadData(fileID, fileSize, Convert.ToInt32(Session["verification"]));

                string contentType = myFile.Type;
                string extension = myFile.Extension;

                //send file to the user's browser
                Response.Clear();
                Response.ContentType = contentType;
                Response.AddHeader("Content-Length", fileSize.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename = " + fileName + extension);
                Response.OutputStream.Write(fileDataBytes, 0, fileDataBytes.Length);
                Response.Flush();
                Response.End();
            }
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            cloud = (FileCloud)Session["cloud"];
            trash = (FileCloud)Session["trash"];
            int accountID = Convert.ToInt32(Session["accountID"]);
            CloudWS.resetStorageUsed(Convert.ToInt32(Session["accountID"]), Convert.ToInt32(Session["verification"]));
            CloudWS.logUserTransaction(accountID, "Deleted all files in their cloud", Convert.ToInt32(Session["verification"]));
            //add files to the trash
            foreach (FileData file in cloud.Files)
            {
                trash.Files.Add(file);
            }
            cloud = new FileCloud();
            Session["trash"] = trash;
            Session["cloud"] = cloud;
            lblMsg.Text = "All files sent to the trash.";

            showFiles();
        }

        protected void btnSync_Click(object sender, EventArgs e)
        {
            if (Session["cloud"] != null)
            {
                // write uploaded files to the DB 
                object files = Session["cloud"];
                int accountID = Convert.ToInt32(Session["accountID"]);
                mySerialization.writeCloud(files, accountID);
            }

            if (Session["trash"] != null)
            {
                // write deleted files to the DB 
                object files = Session["trash"];
                int accountID = Convert.ToInt32(Session["accountID"]);
                mySerialization.writeTrash(files, accountID);
            }
        }
    }
}