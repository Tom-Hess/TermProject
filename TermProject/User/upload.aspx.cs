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
            lblMsg.ForeColor = System.Drawing.Color.Red;
            if(!fuUpload.HasFile)
            {
                lblMsg.Text = "No file selected!";
            }else
            {
                int fileLength = fuUpload.PostedFile.ContentLength;
                byte[] fileData = new byte[fileLength];
                string fileExtension;
                fuUpload.PostedFile.InputStream.Read(fileData, 0, fileLength);
                

                string fileTitle = fuUpload.PostedFile.FileName;
                try
                {
                    fileExtension = fileTitle.Substring(fileTitle.LastIndexOf("."));
                }catch(Exception ex)
                {
                    lblMsg.Text = "Unknown file type";
                    return;
                }

                int index = fileTitle.IndexOf(".");
                if (index > 0)
                    fileTitle = fileTitle.Substring(0, index);
                string fileType = fuUpload.PostedFile.ContentType;

                fileExtension = fileExtension.ToLower();

                string imagePath;

                switch(fileExtension)
                {
                    case ".pdf":
                        imagePath = "~/Images/pdf.jpg";
                        break;
                    case ".jpg":
                        imagePath = "~/Images/jpg.png";
                        break;
                    case ".jpeg":
                        imagePath = "~/Images/jpeg.jpg";
                        break;
                    case ".docx":
                    case ".doc":
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
                    case ".exe":
                        imagePath = "~/Images/exe.jpg";
                        break;
                    case ".mp3":
                        imagePath = "~/Images/mp3.jpg";
                        break;
                    case ".zip":
                        imagePath = "~/Images/zip.jpg";
                        break;
                    default:
                        imagePath = "~/Images/unknown.png";
                        break;
                }

                    lblMsg.Text = fileData.ToString() + fileTitle;

                lblMsg.Text = fileData.ToString() + fileTitle;

                Part2WS.FileData newFileData = new Part2WS.FileData();
                newFileData.AccountID = Convert.ToInt32(Session["AccountID"]);
                newFileData.Email = Session["email"].ToString();
                newFileData.Timestamp = DateTime.Now;
                newFileData.Title = fileTitle;
                newFileData.Type = fileType;
                newFileData.Length = fileLength;
                newFileData.ImagePath = imagePath;
                newFileData.Extension = fileExtension;

                FileCloud cloud = (FileCloud)Session["cloud"];
                cloud.Files.Add(newFileData);

                DataSet tempFile = myUpload.getFile(Session["email"].ToString(), fileTitle, Convert.ToInt32(Session["verification"]));
                myAccount = myUpload.GetAccountInfo(Session["email"].ToString(), Convert.ToInt32(Session["verification"]));
                Int64 projectedRemainStorage = fileLength + myAccount.StorageUsed;

                if (tempFile.Tables[0].Rows.Count > 0)
                {//if file name already exists in the DB
                    lblMsg.Text = "File name exist in the your Cloud. ";
                }
                else if (projectedRemainStorage > myAccount.StorageSpace)
                {//If file size is bigger than the user's current balance
                    lblMsg.Text = "You don't have enough storage in your cloud to store this file. ";
                }
                else
                {
                    if (myUpload.uploadFile(fileTitle, fileType, fileLength, fileData,
                    Session["email"].ToString(), Convert.ToInt32(Session["AccountID"]), imagePath, fileExtension, Convert.ToInt32(Session["verification"])))
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully uploaded " + fileTitle;
                        myUpload.updateStorageUsed(Session["email"].ToString(), projectedRemainStorage, Convert.ToInt32(Session["verification"]));
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