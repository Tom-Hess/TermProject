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
                    break;
                }
            }
            Session["cloud"] = cloud;
            Session["trash"] = trash;

            //update user's storage used - ADD 
            P2WS.updateStorageUsed(Session["email"].ToString(), size, Convert.ToInt32(Session["verification"]));
            showFiles();
        }
    }
}