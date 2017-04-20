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
                        myFile.Title = fileName;
                        break;
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
        }

        protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int fileID = Convert.ToInt32(gvFiles.Rows[index].Cells[1].Text);
            Int64 size = -(Convert.ToInt64(gvFiles.Rows[index].Cells[4].Text));

            cloud = (FileCloud)Session["cloud"];

            for (int i = 0; i < cloud.Files.Count; i++)
            {
                myFile = (FileData)cloud.Files[i];

                if (myFile.FileID == fileID)
                    cloud.Files.RemoveAt(i);
                break;
            }
            Session["cloud"] = cloud;

            //delete the file in the DB
            CloudWS.DeleteFile(fileID, Convert.ToInt32(Session["verification"]));
            //update user's storage used
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
    }
}