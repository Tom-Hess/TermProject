using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TermProjectLibrary;
using TermProject.RegistrationWS;
using System.Data;

namespace TermProject.LoginB
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        int verificationToken = 112358;
        string defaultPassword = "password";

        Validation myValidation = new Validation();
        Part2WS.Part2WS P2WS = new Part2WS.Part2WS();
        Part2WS.Person accountInfo = new Part2WS.Person();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMethod1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                lblMsg1.Text = "Email cannot be blank. ";
            }
            else if (!myValidation.IsValidEmail(txtEmail.Text))
            {
                lblMsg1.Text = "Not a valid email address. ";
            }
            else
            {
                accountInfo = P2WS.GetAccountInfo(txtEmail.Text, verificationToken);
                lblM1email.Text = accountInfo.Email;
                lblM1Name.Text = accountInfo.Name;
                lblM1password.Text = accountInfo.Password;
                lblM1StorageSpace.Text = accountInfo.StorageSpace.ToString();
                lblM1StorageUsed.Text = accountInfo.StorageUsed.ToString();
                lblM1AccountType.Text = accountInfo.AccountType.ToString();
            }
        }

        protected void btnM2submit_Click(object sender, EventArgs e)
        {
            if (txtM2newEmail.Text == "")
            {
                lblMsg1.Text = "Email cannot be blank. ";
            }
            else if (!myValidation.IsValidEmail(txtM2newEmail.Text))
            {
                lblMsg1.Text = "Not a valid email address. ";
            }
            else
            {
                string tempEmail = accountInfo.Email;
                accountInfo.Email = txtM2newEmail.Text;
                P2WS.UpdateAccount(accountInfo, tempEmail, verificationToken);
            }
        }

        protected void btnM3submit_Click(object sender, EventArgs e)
        {
            lblM3msg.ForeColor = System.Drawing.Color.Red;
            if (!fuUpload.HasFile)
            {
                lblM3msg.Text = "No file selected!";
            }
            else
            {
                int fileLength = fuUpload.PostedFile.ContentLength;
                byte[] fileData = new byte[fileLength];

                fuUpload.PostedFile.InputStream.Read(fileData, 0, fileLength);
                string fileTitle = fuUpload.PostedFile.FileName;
                string fileType = fuUpload.PostedFile.ContentType;

                string fileExtension = fileTitle.Substring(fileTitle.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();

                string imagePath;

                switch (fileExtension)
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

                lblM3msg.Text = fileData.ToString() + fileTitle;

                lblM3msg.Text = fileData.ToString() + fileTitle;

                DataSet tempFile = P2WS.getFile(Session["email"].ToString(), fileTitle, Convert.ToInt32(Session["verification"]));
                accountInfo = P2WS.GetAccountInfo(Session["email"].ToString(), Convert.ToInt32(Session["verification"]));
                Int64 projectedRemainStorage = fileLength + accountInfo.StorageUsed;

                if (tempFile.Tables[0].Rows.Count > 0)
                {//if file name exist in the DB
                    lblM3msg.Text = "File name exist in the your Cloud. ";
                }
                else if (projectedRemainStorage > accountInfo.StorageSpace)
                {//If file size is bigger than the user's current balance
                    lblM3msg.Text = "You don't have enough storage in your cloud to store this file. ";
                }
                else
                {
                    if (P2WS.uploadFile(fileTitle, fileType, fileLength, fileData,
                    Session["email"].ToString(), Convert.ToInt32(Session["AccountID"]), imagePath, Convert.ToInt32(Session["verification"])))
                    {
                        lblM3msg.ForeColor = System.Drawing.Color.Green;
                        lblM3msg.Text = "Successfully uploaded " + fileTitle;
                        P2WS.updateStorageUsed(Session["email"].ToString(), projectedRemainStorage, Convert.ToInt32(Session["verification"]));
                    }
                    else
                    {
                        lblM3msg.Text = "Failed to upload file. ";
                    }
                }
            }
        }

        protected void btnM4submit_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (txtM4ID.Text == "")
            {
                lblM4msg.Text = "ID cannot be blank. ";
            }
            else if (!int.TryParse(txtM4ID.Text, out temp))
            {
                lblM4msg.Text = "ID must be integer. ";
            }
            else
            {
                try
                {
                    DataSet myDS = P2WS.getFiles(temp, verificationToken);

                    gvM4.DataSource = myDS;
                    gvM4.DataBind();
                }
                catch
                {
                    lblM4msg.Text = "Unable to locate this account. ";
                }
            }
            
        }

        protected void btnM5submit_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (txtM5ID.Text == "")
            {
                lblM5msg.Text = "ID cannot be blank. ";
            }
            else if (!int.TryParse(txtM5ID.Text, out temp))
            {
                lblM5msg.Text = "ID must be an integer. ";
            }
            else if (txtM5name.Text == "")
            {
                lblM5msg.Text = "File Name cannot be blank. ";
            }
            else
            {
                P2WS.UpdateFile(temp, txtM5name.Text, verificationToken);
            }
        }

        protected void btnM6msg_Click(object sender, EventArgs e)
        {
            DateTime begin, end;
            if (myValidation.IsEmpty(txtEmail.Text))
            {
                lblM6msg.Text = "Email cannot be blank. ";
                txtM6email.Focus();
            }
            else if (!myValidation.IsValidEmail(txtEmail.Text))
            {
                lblM6msg.Text = "Not a valid email address. ";
                txtEmail.Focus();
            }
            else if (myValidation.IsEmpty(txtM6from.Text))
            {
                lblM6msg.Text = "From field cannot be blank. ";
                txtM6from.Focus();
            }
            else if (!DateTime.TryParse(txtM6from.Text, out begin))
            {
                lblM6msg.Text = "Invalid date format in From field. Put date in the format mm/dd/yyyy";
                txtM6from.Focus();
            }
            else if (myValidation.IsEmpty(txtM6to.Text))
            {
                lblM6msg.Text = "To field cannot be blank. ";
                txtM6to.Focus();
            }
            else if (!DateTime.TryParse(txtM6to.Text, out end))
            {
                lblM6msg.Text = "Invalid date format in To field. Put date in the format mm/dd/yyyy";
                txtM6to.Focus();
            }
            else if (begin > end)
            {
                lblM6msg.Text = "From date cannot be later than To date. ";
                txtM6to.Focus();
            }
            else
            {
                //passed all validation. Show the transactions in the gridview.
                string email = txtEmail.Text;

                DataSet myDS = P2WS.getUploadHistory(email, begin, end, verificationToken);
                gvM6.DataSource = myDS;
                gvM6.DataBind();
            }
        }

        protected void btnM7Submit_Click(object sender, EventArgs e)
        {
            int temp;
            if (txtM7ID.Text == "")
                lblM7msg.Text = "File ID cannot be blank. ";
            else if (!int.TryParse(txtM7ID.Text, out temp) && temp > 0)
                lblM7msg.Text = "File ID must be positive integer. ";
            else
                P2WS.DeleteFile(temp, Convert.ToInt32(Session["verification"]));
        }

        protected void btnM8submit_Click(object sender, EventArgs e)
        {
            Int64 temp;
            if (txtM8email.Text == "")
                lblM8msg.Text = "Email cannot be blank. ";
            else if (!myValidation.IsValidEmail(txtM8email.Text))
                lblM8msg.Text = "Not an valid email. Try again. ";
            else if (txtM8size.Text == "")
                lblM8msg.Text = "Size cannot be blank. ";
            else if (!Int64.TryParse(txtM8size.Text, out temp))
                lblM8msg.Text = "Size must be an integer, can be positive or negative. ";
            else
                P2WS.updateStorageUsed(txtM8email.Text, temp, verificationToken);
        }

        protected void btnM9submit_Click(object sender, EventArgs e)
        {
            DataSet myDS = P2WS.getAllAccount(verificationToken);
            gvM9.DataSource = myDS;
            gvM9.DataBind();
        }

        protected void btnM10submit_Click(object sender, EventArgs e)
        {
            if (txtM10ID.Text == "")
                lblM10msg.Text = "ID cannot be blank. ";
            else if (txtM10ID.Text)
        }
    }
}