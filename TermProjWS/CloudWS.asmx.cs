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
    /// Summary description for CloudWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CloudWS : System.Web.Services.WebService
    {
        Serialize mySerialization = new Serialize();
        DBConnect myDB = new DBConnect();
        int verificationToken = 112358;
        SqlCommand myCommand = new SqlCommand();

        [WebMethod]
        public bool addDownloadData (int accountID, byte[] data, int verification)
        {
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPaddDownloadData";
                myCommand.Parameters.AddWithValue("@accountID", accountID);
                myCommand.Parameters.AddWithValue("@data", data);

                myDB.DoUpdateUsingCmdObj(myCommand);
                return true;

            }else
            {
                return false;
            }
        }

        [WebMethod]
        public int getMaxFileID(int verification)
        {
            int returnID;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetMaxFileID";
                myDB.GetDataSetUsingCmdObj(myCommand);

                returnID = Convert.ToInt32(myDB.GetField("MaxID", 0));
                return returnID;

            }
            else
            {
                return 0;
            }
        }
    }
}
