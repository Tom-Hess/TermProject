using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream
using TermProjectLibrary;

namespace TermProject.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Part2WS.Part2WS myUpload = new Part2WS.Part2WS();

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
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(!fuUpload.HasFile)
            {
                lblMsg.Text = "No file selected!";
            }else
            {
                int fileLength = fuUpload.PostedFile.ContentLength;
                byte[] fileData = new byte[fileLength];

                fuUpload.PostedFile.InputStream.Read(fileData, 0, fileLength);
                string fileTitle = fuUpload.PostedFile.FileName;
                string fileType = fuUpload.PostedFile.ContentType;
                
                //BinaryFormatter serializer = new BinaryFormatter();
                //MemoryStream memStream = new MemoryStream();
                //Byte[] byteArray;
                //serializer.Serialize(memStream, fuUpload.PostedFile);
                //byteArray = memStream.ToArray();

                lblMsg.Text = fileData.ToString() + fileTitle;

                if (myUpload.uploadFile(fileTitle, fileType, fileLength, fileData, Session["email"].ToString(), 112358))
                {
                    lblMsg.Text = "Upload successful. ";
                }
                else
                {
                    lblMsg.Text = "Failed to upload file. ";
                }
            }
        }
    }
}