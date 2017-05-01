using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using TermProjectLibrary;

namespace TermProjWS
{
    /// <summary>
    /// Summary description for Part2WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Part2WS : System.Web.Services.WebService
    {
        SqlCommand myCommand = new SqlCommand();
        DBConnect myDB = new DBConnect();
        PWEncryption myEncryption = new PWEncryption();
        DataSet myDS = new DataSet();
        int verificationToken = 112358;
        string defaultPassword = "password";
        [WebMethod]

        public Person GetAccountInfo(string email, int verification)
        {
            Person accountInfo = new Person();

            if (verification == verificationToken)
            {
                //get account information given the email address
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "GetAccountInfoGivenEmail";

                SqlParameter myParameter = new SqlParameter("Email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myDB.GetDataSetUsingCmdObj(myCommand);
                string password = myDB.GetField("Password", 0).ToString();
                password = myEncryption.DecryptString(password);
                string name = myDB.GetField("Name", 0).ToString();
                Int64 storageSpace = Int64.Parse(myDB.GetField("StorageSpace", 0).ToString());
                Int64 storageUsed = Int64.Parse(myDB.GetField("StorageUsed", 0).ToString());

                accountInfo.Password = password;
                accountInfo.Email = email;
                accountInfo.Name = name;
                accountInfo.StorageSpace = storageSpace;
                accountInfo.StorageUsed = storageUsed;
                accountInfo.AccountType = int.Parse(myDB.GetField("AccountType", 0).ToString());
                accountInfo.AccountID = int.Parse(myDB.GetField("AccountID", 0).ToString());
            }
            return accountInfo;
        }

        [WebMethod]
        public bool UpdateAccount(Person updatePerson, string oldEmail, int verification)
        {
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPCheckEmail";
                SqlParameter inputParameter = new SqlParameter("@Email", updatePerson.Email);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(inputParameter);

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
                int count = myDS.Tables[0].Rows.Count;
                if (count == 0)
                {
                    myCommand.Parameters.Clear();
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "UpdateAccount";
                    inputParameter = new SqlParameter("@OldEmail", oldEmail);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    myCommand.Parameters.Add(inputParameter);

                    string password = myEncryption.EncryptString(updatePerson.Password);

                    inputParameter = new SqlParameter("@Password", password);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    myCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@NewEmail", updatePerson.Email);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    myCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@Name", updatePerson.Name);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    myCommand.Parameters.Add(inputParameter);

                    myDB.DoUpdateUsingCmdObj(myCommand);
                    return true;

                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        [WebMethod]
        public bool uploadFile(string title, string type, Int64 length, byte[] data, string email, int accountID, string imagePath, string extension, int verification)
        {
            if(verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPuploadFile";

                SqlParameter myParameter = new SqlParameter("@title", title);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@extension", extension);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@type", type);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@imagePath", imagePath);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@accountID", accountID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@length", length);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.BigInt;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@data", data);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarBinary;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                int returnValue = myDB.DoUpdateUsingCmdObj(myCommand);
                if (returnValue > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else
            {
                return false;
            }
            
        }

        [WebMethod]
        public DataSet getFiles(int accountID, int verification)
        {
            myDS = new DataSet();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPGetFiles";

                SqlParameter myParameter = new SqlParameter("@accountID", accountID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            }
            return myDS;
        }

        [WebMethod]
        public void UpdateFile(int fileID, string fileName, int verification)
        {
            if(verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPUpdateFile";

                SqlParameter myParameter = new SqlParameter("@ID", fileID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@title", fileName);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myDB.DoUpdateUsingCmdObj(myCommand);
            }

        }
        [WebMethod]
        public DataSet getUploadHistory(string email, DateTime fromDate, DateTime toDate, int verification)
        {
            myDS = new DataSet();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetHistoryByEmail";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@start", fromDate);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@end", toDate);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            }
            return myDS;
        }

        [WebMethod]
        public int DeleteFile(int fileID, int verification)
        {
            int temp = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPdeleteFile";

                SqlParameter myParameter = new SqlParameter("@ID", fileID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                temp = myDB.DoUpdateUsingCmdObj(myCommand);
                return temp;
            }
            else
                return temp;

        }
        [WebMethod]
        public DataSet getFile(string email, string fileName, int verification)
        {
            //Get a user's file
            if (verification == verificationToken)
            {
                //get account information given the email address
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetFile";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@name", fileName);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                DataSet myds = myDB.GetDataSetUsingCmdObj(myCommand);
                return myds;
            }
            else
                return null;

        }
        [WebMethod]
        public void updateStorageUsed(string email, Int64 storageUsed, int verification)
        {//Can be used to add or minus storageUsed
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPupdateStorageUsed";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@storageUsed", storageUsed);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.BigInt;
                myCommand.Parameters.Add(myParameter);

                myDB.DoUpdateUsingCmdObj(myCommand);
            }
        }
        [WebMethod]
        public DataSet getAllAccount(int verification)
        {
            myDS = new DataSet();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetAllAccounts";

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            }
            return myDS;
        }

        [WebMethod]
        public DataSet getAllAdmin(int verification)
        {
            myDS = new DataSet();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetAllAdmin";

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            }
            return myDS;
        }

        [WebMethod]
        public void updateStorageCapacity(int ID, int adminID, Int64 capacity, int verification)
        {
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPupdateStorageCapacity";

                SqlParameter myParameter = new SqlParameter("@accountID", ID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@adminID", adminID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@storageCapacity", capacity);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.BigInt;
                myCommand.Parameters.Add(myParameter);

                myDB.DoUpdateUsingCmdObj(myCommand);
            }
        }
        [WebMethod]
        public int deleteAccount(int ID, int adminID, int verification)
        {
            int flag = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPdeleteAccount";

                SqlParameter myParameter = new SqlParameter("@ID", ID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@adminID", adminID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                flag = myDB.DoUpdateUsingCmdObj(myCommand);
                return flag;
                //Flag represense number of rows affected,-1 if exception occured, 
            }
            else
                return flag; //return zero
        }

        [WebMethod]
        public int resetPassord(int ID, int adminID, int verification)
        {
            string encryptedDP = myEncryption.EncryptString(defaultPassword);
            int flag = 0;// rows affected by this action, -1 if except occured

            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPresetPassword";

                SqlParameter myParameter = new SqlParameter("@ID", ID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@adminID", adminID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@defaultPassword", encryptedDP);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                flag = myDB.DoUpdateUsingCmdObj(myCommand);
                return flag;
            }
            else
                return flag;
        }

        [WebMethod]
        public byte[] GetFileData(int fileID, Int64 fileSize, int verification)
        {
            byte[] data = new byte[fileSize];

            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetFileData";

                SqlParameter myParameter = new SqlParameter("@fileID", fileID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myDB.GetDataSetUsingCmdObj(myCommand);
            }

            data = (byte[])(myDB.GetField("data", 0));
            return data;

        }

        [WebMethod]
        public FileData getAllFileInfo(int fileID, int verification)
        {
            FileData returnFile = new FileData();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetFileInfoGivenID";

                SqlParameter myParameter = new SqlParameter("@ID", fileID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myDB.GetDataSetUsingCmdObj(myCommand);


                returnFile.FileID = fileID;
                returnFile.AccountID = Convert.ToInt32(myDB.GetField("accountID", 0));
                returnFile.Data = (byte[])myDB.GetField("data", 0);
                returnFile.Email = myDB.GetField("email", 0).ToString();
                returnFile.Title = myDB.GetField("title", 0).ToString();
                returnFile.Type = myDB.GetField("type", 0).ToString();
                returnFile.ImagePath = myDB.GetField("imagePath", 0).ToString();
                returnFile.Length = Convert.ToInt64(myDB.GetField("length", 0));
                returnFile.Timestamp = (DateTime)(myDB.GetField("timestamp", 0));
                returnFile.Extension = myDB.GetField("extension", 0).ToString();
            }
            return returnFile;
        }

        [WebMethod]
        public int activateOrDeactivate(int userID, int adminID, int verification)
        {
            int temp = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPactivateOrDeactivateAccount";

                SqlParameter myParameter = new SqlParameter("@userID", userID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@adminID", adminID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                temp = myDB.DoUpdateUsingCmdObj(myCommand);
                return temp;
            }
            else
                return temp;
        }

        [WebMethod]
        public DataSet getAdminLog(int adminID, int verification)
        {
            myDS = new DataSet();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetAdminLog";

                SqlParameter myParameter = new SqlParameter("@adminID", adminID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            }
            return myDS;
        }

        [WebMethod]
        public DataSet getForum(int verification)
        {
            myDS = new DataSet();
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetForum";

                myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            }
            return myDS;
        }

        [WebMethod]
        public int addQuestion(string email, string question, int verification)
        {
            int temp = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPaddQuestion";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@question", question);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                temp = myDB.DoUpdateUsingCmdObj(myCommand);
                return temp;
            }
            else
                return temp;
        }

        [WebMethod]
        public int addAnswer(string email, string question, int ID, int verification)
        {
            int temp = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPaddAnser";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@question", question);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@ID", ID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                temp = myDB.DoUpdateUsingCmdObj(myCommand);
                return temp;
            }
            else
                return temp;
        }

        [WebMethod]
        public int updatePassword(string email, string password, int verification)
        {
            string encryptedPW = myEncryption.EncryptString(password);
            int flag = 0;// rows affected by this action, -1 if except occured

            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPupdatePassword";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@password", encryptedPW);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                flag = myDB.DoUpdateUsingCmdObj(myCommand);
                return flag;
            }
            else
                return flag;
        }

        [WebMethod]
        public int updateStorage(string email, Int32 option, int verification)
        {
            int flag = 0;// rows affected by this action, -1 if except occured

            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPupgradeStorageByEmail";

                SqlParameter myParameter = new SqlParameter("@email", email);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.VarChar;
                myCommand.Parameters.Add(myParameter);

                myParameter = new SqlParameter("@storage", option);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.BigInt;
                myCommand.Parameters.Add(myParameter);

                flag = myDB.DoUpdateUsingCmdObj(myCommand);
                return flag;
            }
            else
                return flag;
        }
    }
}
