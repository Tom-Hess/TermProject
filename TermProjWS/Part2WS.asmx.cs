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

        [WebMethod]
        public Person GetAccountInfo(string email)
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

            Person accountInfo = new Person();
            accountInfo.Password = password;
            accountInfo.Email = email;
            accountInfo.Name = name;

            return accountInfo;
        }

        [WebMethod]
        public void UpdateAccount(Person updatePerson, string oldEmail)
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
}
