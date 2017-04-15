using System;
using System.Collections;
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
    /// Summary description for RegistrationWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RegistrationWS : System.Web.Services.WebService
    {
        SqlCommand myCommand = new SqlCommand();
        DBConnect myDB = new DBConnect();
        PWEncryption myEncryption = new PWEncryption();
        DataSet myDS = new DataSet();

        [WebMethod]
        public bool AddAccount(Person newPerson)
        {
            myCommand.Parameters.Clear();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "AddAccount";

            SqlParameter myParameter = new SqlParameter("Name", newPerson.Name);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(myParameter);

            string encryptedPW = myEncryption.EncryptString(newPerson.Password);

            myParameter = new SqlParameter("Password", encryptedPW);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(myParameter);

            myParameter = new SqlParameter("Email", newPerson.Email);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(myParameter);

            myParameter = new SqlParameter("StorageSpace", newPerson.StorageSpace);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.BigInt;
            myCommand.Parameters.Add(myParameter);

            myParameter = new SqlParameter("AccountType", newPerson.AccountType);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(myParameter);

            int returnValue = myDB.DoUpdateUsingCmdObj(myCommand);
            if(returnValue > 0 )
            {
                return true;
            } else
            {
                return false;
            }
        }
        [WebMethod]
        public ArrayList ValidateLogin(string email, string PW)
        {
            ArrayList myAL = new ArrayList();
            int count = 0;

            myCommand.Parameters.Clear();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "CheckAccount";
            SqlParameter inputParameter = new SqlParameter("@Email", email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(inputParameter);

            string encryptedPW = myEncryption.EncryptString(PW);

            inputParameter = new SqlParameter("@PassWord", encryptedPW);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(inputParameter);

            myDS = myDB.GetDataSetUsingCmdObj(myCommand);
            count = myDS.Tables[0].Rows.Count;
            myAL.Add(count);

            if(count > 0)
            {
                myDB.GetDataSetUsingCmdObj(myCommand);
                int accountType = Convert.ToInt32(myDB.GetField("AccountType", 0));
                myAL.Add(accountType);
                int accountID = Convert.ToInt32(myDB.GetField("AccountID", 0));
                myAL.Add(accountID);
            }

            return myAL;
        }
        
    }
}
