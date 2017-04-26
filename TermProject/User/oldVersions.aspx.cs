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
    public partial class WebForm5 : System.Web.UI.Page
    {
        DataSet myDS = new DataSet();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();
        Validation myValidation = new Validation();
        FileCloud cloud = new FileCloud();
        FileData myFile = new FileData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 1)
            {
                Response.Redirect("../logout.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    showFiles();
                    if (gvFiles.Rows.Count == 0)
                        btnEmptyFiles.Visible = false;
                }
            }
        }

        public void showFiles()
        {
            //get data source of old version information and bind to the GV
            myDS = CloudWS.getPreviousFiles(Convert.ToInt32(Session["accountID"]), Convert.ToInt32(Session["verification"]));
            gvFiles.DataSource = myDS;
            gvFiles.DataBind();
            if (gvFiles.Rows.Count == 0)
                btnEmptyFiles.Visible = false;
        }

        protected void btnEmptyFiles_Click(object sender, EventArgs e)
        {
            //delete from previousversions table where accountID = the current accountID
            CloudWS.deletePreviousVersions(Convert.ToInt32(Session["accountID"]), Convert.ToInt32(Session["verification"]));

            CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                            "Emptied their previous file versions", Convert.ToInt32(Session["verification"]));

            showFiles();
            lblMsg.Text = "All files were deleted.";
        }

        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int fileID = Convert.ToInt32(gvFiles.Rows[index].Cells[0].Text);
                string timestamp = gvFiles.Rows[index].Cells[2].Text;
                int size = Convert.ToInt32(gvFiles.Rows[index].Cells[3].Text);
                //delete from DB where fileID = fileID and timestamp = timestamp and size = size
                CloudWS.deletePreviousVersion(fileID, timestamp, size, Convert.ToInt32(Session["verification"]));
                showFiles();
                CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                            "Deleted file ID# " + fileID + "version from " + timestamp, Convert.ToInt32(Session["verification"]));
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                //restore the previous version of the file to the user's cloud
                int fileID = Convert.ToInt32(gvFiles.Rows[index].Cells[0].Text);
                Int64 size = Convert.ToInt64(gvFiles.Rows[index].Cells[3].Text);
                string timestamp = gvFiles.Rows[index].Cells[2].Text;
                Int64 lengthDifference = 0;

                cloud = (FileCloud)Session["cloud"];
                bool found = false;
                Int64 oldLength;
                for (int i = 0; i < cloud.Files.Count; i++)
                {
                    myFile = (FileData)cloud.Files[i];

                    if (myFile.FileID == fileID)
                    {
                        found = true;
                        oldLength = myFile.Length;
                        myFile.Timestamp = Convert.ToDateTime(timestamp);
                        myFile.Length = size;
                        lengthDifference = size - myFile.Length;
                        CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                                "Restored file ID #" + myFile.FileID + " to the version from " +
                                timestamp, Convert.ToInt32(Session["verification"]));
                        break;
                    }
                }

                if (found)
                {
                    //get previous version's data, delete from previous versions table
                    byte[] oldData = CloudWS.getPreviousDownloadData(fileID, size, timestamp, Convert.ToInt32(Session["verification"]));
                    //update downloaddata
                    CloudWS.updateDownloadData(oldData, fileID, Convert.ToInt32(Session["verification"]));

                    //update user's storage used 
                    P2WS.updateStorageUsed(Session["email"].ToString(), lengthDifference, Convert.ToInt32(Session["verification"]));
                    showFiles();

                    CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                                "Restored file ID #" + fileID + " to the version from " + timestamp,
                                Convert.ToInt32(Session["verification"]));

                    Session["cloud"] = cloud;
                }
                else
                {
                    lblMsg.Text = "File was not found in your cloud.";
                }
                showFiles();
            }
        }
    }
}