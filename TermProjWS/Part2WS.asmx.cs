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
    // [System.Web.Script.Services.ScriptService]
    public class Part2WS : System.Web.Services.WebService
    {
        SqlCommand myCommand = new SqlCommand();
        DBConnect myDB = new DBConnect();
        PWEncryption myEncryption = new PWEncryption();
        DataSet myDS = new DataSet();
        int verificationToken = 112358;
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
            }
            return accountInfo;
        }

        [WebMethod]
        public void UpdateAccount(Person updatePerson, string oldEmail, int verification)
        {
            if(verification == verificationToken)
            {
                myCommand.Parameters.Clear();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "UpdateAccount";
                SqlParameter inputParameter = new SqlParameter("@OldEmail", oldEmail);
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
            }
            

        }

        [WebMethod]
        public bool uploadFile(string title, string type, Int64 length, byte[] data, string email, int accountID, string imagePath, int verification)
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
                myCommand.CommandText = "TPGetFiles";

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
        public void DeleteFile(int fileID, int verification)
        {
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPDeleteFile";

                SqlParameter myParameter = new SqlParameter("@ID", fileID);
                myParameter.Direction = ParameterDirection.Input;
                myParameter.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(myParameter);

                myDB.DoUpdateUsingCmdObj(myCommand);
            }

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

    }
}
