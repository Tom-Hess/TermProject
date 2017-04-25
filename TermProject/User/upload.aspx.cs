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
using TermProject.Part2WS;

namespace TermProject.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Part2WS.Part2WS myUpload = new Part2WS.Part2WS();
        Part2WS.Person myAccount = new Part2WS.Person();
        CloudWS.CloudWS CloudWS = new CloudWS.CloudWS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Login"]) != 1)
            {
                Response.Redirect("../logout.aspx");
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
                byte[] fileData = ReadFully(fuUpload.PostedFile.InputStream, fileLength);
                string fileExtension;

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

                string imagePath = "";
                bool valid = true;

                switch (fileExtension)
                {
                    case ".pdf":
                        imagePath = "~/Images/pdf.jpg";
                        break;
                        //images cannot be uploaded
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        valid = false;
                        break;
                    case ".docx":
                    case ".doc":
                        imagePath = "~/Images/word.jpg";
                        break;
                    case ".xlsx":
                        imagePath = "~/Images/xslx.png";
                        break;
                    case ".txt":
                        imagePath = "~/Images/txt.jpg";
                        break;
                    case ".aspx":
                        imagePath = "~/Images/aspx.jpg";
                        break;
                    case ".pptx":
                    case ".ppt":
                        imagePath = "~/Images/pptx.png";
                        break;
                    case ".exe":
                        imagePath = "~/Images/exe.jpg";
                        break;
                        //music files cannot be uploaded
                    case ".mp3":
                        valid = false;
                        break;
                    case ".zip":
                    case ".7z":
                        imagePath = "~/Images/zip.jpg";
                        break;
                        //video formats cannot be uploaded
                    case ".mp4":
                    case ".gif":
                    case ".wmv":
                    case ".avi":
                    case ".flv":
                    case ".wav":
                    case ".wma":
                        valid = false;
                        break;
                    default:
                        imagePath = "~/Images/unknown.png";
                        break;
                }
                

                if(valid)
                {
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

                    myAccount = myUpload.GetAccountInfo(Session["email"].ToString(),
                        Convert.ToInt32(Session["verification"]));
                    FileCloud cloud = (FileCloud)Session["cloud"];
                    bool exists = false;
                    FileData myFile = new FileData();

                    int oldLength = 0;
                    int newLength;
                    byte[] oldFileData = null;
                    int oldFileID = 0;
                    DateTime oldTimeStamp = DateTime.Now;
                    for (int i = 0; i < cloud.Files.Count; i++)
                    {
                        myFile = (FileData)cloud.Files[i];

                        if (myFile.Title == fileTitle && myFile.Type == fileType)
                        {
                            exists = true;
                            oldLength = Convert.ToInt32(myFile.Length);
                            newLength = fileLength;
                            newFileData.FileID = myFile.FileID;
                            fileLength = newLength - oldLength;
                            if (fileData == CloudWS.getDownloadData(myFile.FileID, oldLength, 
                                Convert.ToInt32(Session["verification"])))
                            {
                                lblMsg.Text = "File already exists in your cloud, file was not uploaded.";
                                return;
                            }else
                            {
                                //get old file's time of upload
                                oldTimeStamp = myFile.Timestamp;
                                //update the cloud data to the new file's size and time of upload
                                myFile.Length = newLength;
                                myFile.Timestamp = DateTime.Now;
                                
                                oldFileID = myFile.FileID;
                                //get old file's data to upload to the server
                                oldFileData = CloudWS.getDownloadData(myFile.FileID, 
                                    oldLength, Convert.ToInt32(Session["verification"]));
                            }
                        }

                    }

                    if (fileLength > (myAccount.StorageSpace - myAccount.StorageUsed))
                    {//If file size is bigger than the user's current balance
                        lblMsg.Text = "You don't have enough storage in your cloud to store this file. ";
                    }
                    else if(exists)
                    {
                        //add previous version to the DB for previous version restoration, including data and the time of upload
                        CloudWS.addPreviousDownloadData(Convert.ToInt32(Session["accountID"]), 
                            oldFileData, oldFileID, oldTimeStamp, fileTitle, oldLength, Convert.ToInt32(Session["verification"]));

                        //update storage used based on the difference in file lengths (new - old lengths)
                        myUpload.updateStorageUsed(Session["email"].ToString(), fileLength,
                            Convert.ToInt32(Session["verification"]));

                        //update the file version in DownloadData - update data given file ID and new data
                        CloudWS.updateDownloadData(fileData, oldFileID, Convert.ToInt32(Session["verification"]));

                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "A previous version of the file was updated.";
                        cloud = (FileCloud)Session["cloud"];
                    }
                    else
                    {
                        int ID = CloudWS.addDownloadData(Convert.ToInt32(Session["AccountID"]),
                            fileData, Convert.ToInt32(Session["verification"]));
                        myUpload.updateStorageUsed(Session["email"].ToString(), fileLength,
                            Convert.ToInt32(Session["verification"]));
                        CloudWS.logUserTransaction(Convert.ToInt32(Session["accountID"]), 
                            "Uploaded file with ID #" + ID, Convert.ToInt32(Session["verification"]));

                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully uploaded " + fileTitle;
                        newFileData.FileID = ID;

                        cloud = (FileCloud)Session["cloud"];
                        cloud.Files.Add(newFileData);
                    }
                }else
                {
                    lblMsg.Text = "Invalid file type. Images, videos and music files cannot be uploaded.";
                }
                
            }
        }
                
        public static byte[] ReadFully(Stream stream, int initialLength)
        {//http://www.yoda.arachsys.com/csharp/readbinary.html
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }
    }
}