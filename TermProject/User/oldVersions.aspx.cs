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

        protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //restore the previous version of the file to the user's cloud
            int index = e.RowIndex;
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

            if(found)
            {
                //get previous version's data, delete from previous versions table
                byte[] oldData = CloudWS.getPreviousDownloadData(fileID, size, timestamp, Convert.ToInt32(Session["verification"]));
                //update downloaddata
                CloudWS.updateDownloadData(oldData, fileID, Convert.ToInt32(Session["verification"]));

                //update user's storage used 
                P2WS.updateStorageUsed(Session["email"].ToString(), lengthDifference, Convert.ToInt32(Session["verification"]));
                showFiles();
                lblMsg.Text = "Successfully restored file ID #" + fileID + " to the version from " + timestamp;

                CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]),
                            "Restored file ID #" + fileID + " to the version from " + timestamp,
                            Convert.ToInt32(Session["verification"]));

                Session["cloud"] = cloud;
            }else
            {
                lblMsg.Text = "File was not found in your cloud.";
            }

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
    }
}