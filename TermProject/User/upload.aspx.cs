using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream
using TermProjectLibrary;
using System.Data;

namespace TermProject.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Part2WS.Part2WS myUpload = new Part2WS.Part2WS();
        Part2WS.Person myAccount = new Part2WS.Person();
        int verification = 112358;
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

                string fileExtension = fileTitle.Substring(fileTitle.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();

                string imagePath;

                switch(fileExtension)
                {
                    case ".jpg":
                        imagePath = "~/Images/jpg.png";
                        break;
                    case ".jpeg":
                        imagePath = "~/Images/jpeg.jpg";
                        break;
                    case ".docx":
                        imagePath = "~/Images/word.jpg";
                        break;
                    case ".gif":
                        imagePath = "~/Images/gif.jpg";
                        break;
                    case ".png":
                        imagePath = "~/Images/png.jpg";
                        break;
                    case ".xlsx":
                        imagePath = "~/Images/xslx.png";
                        break;
                    case ".pptx":
                        imagePath = "~/Images/pptx.png";
                        break;
                    default:
                        imagePath = "~/Images/unknown.png";
                        break;
                }

                    lblMsg.Text = fileData.ToString() + fileTitle;

                lblMsg.Text = fileData.ToString() + fileTitle;

                DataSet tempFile = myUpload.getFile(Session["email"].ToString(), fileTitle, verification);
                myAccount = myUpload.GetAccountInfo(Session["email"].ToString(), verification);

                if (tempFile.Tables[0].Rows.Count > 0)
                {//if file name exist in the DB
                    lblMsg.Text = "File name exist in the your Cloud. ";
                }
                else if ((fileLength + myAccount.StorageUsed) > myAccount.StorageSpace)
                {//If file size is bigger than the user's current balance
                    lblMsg.Text = "You don't have enough storage in your cloud to store this file. ";
                }
                else
                {
                    if (myUpload.uploadFile(fileTitle, fileType, fileLength, fileData,
                    Session["email"].ToString(), Convert.ToInt32(Session["AccountID"]), imagePath, verification))
                    {
                        lblMsg.Text = "Upload successful. ";
                        myUpload.updateStorageUsed(Session["email"].ToString(), fileLength, verification);
                    }
                    else
                    {
                        lblMsg.Text = "Failed to upload file. ";
                    }
                }
            }
        }
    }
}