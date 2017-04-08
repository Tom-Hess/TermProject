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

        [WebMethod]
        public bool AddAdmin(Person newAdmin)
        {
            myCommand.Parameters.Clear();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "AddAdmin";

            SqlParameter myParameter = new SqlParameter("Name", newAdmin.Name);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(myParameter);

            string encryptedPW = myEncryption.EncryptString(newAdmin.Password);

            myParameter = new SqlParameter("Password", encryptedPW);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.VarChar;
            myCommand.Parameters.Add(myParameter);

            myParameter = new SqlParameter("Email", newAdmin.Email);
            myParameter.Direction = ParameterDirection.Input;
            myParameter.SqlDbType = SqlDbType.VarChar;
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
    }
}
