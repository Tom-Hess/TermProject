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

        //[WebMethod]
        //public int writeCloud(Object fileCloud, int accountID)
        //{
        //    Byte[] byteArray;
        //    SqlCommand objCommand = new SqlCommand();

        //    int returnValue;

        //    byteArray = mySerialization.SerializeToByteArray(fileCloud);
        //    //this updates cart that already exists
        //    objCommand.CommandText = "TPwriteCloud";
        //    objCommand.CommandType = CommandType.StoredProcedure;

        //    objCommand.Parameters.AddWithValue("@fileCloud", byteArray);
        //    objCommand.Parameters.AddWithValue("@accountID", accountID);
        //    returnValue = myDB.DoUpdateUsingCmdObj(objCommand);
        //    return returnValue;
        //}

        ////check if a cloud user already has cloud data
        //[WebMethod]
        //public bool checkCloudExists(int accountID)
        //{
        //    SqlCommand objCommand = new SqlCommand();
        //    DataSet myDS;

        //    objCommand.CommandText = "TPgetFileCloud";
        //    objCommand.CommandType = CommandType.StoredProcedure;

        //    objCommand.Parameters.AddWithValue("@accountID", accountID);
        //    myDS = myDB.GetDataSetUsingCmdObj(objCommand);

        //    if (myDS.Tables[0].Rows.Count > 0)
        //        return true;
        //    else
        //        return false;
        //}

        ////get a user's cloud data
        //[WebMethod]
        //public Object getFileCloud(int accountID)
        //{
        //    SqlCommand objCommand = new SqlCommand();
        //    DataSet myDS;
        //    Byte[] byteArray;

        //    objCommand.CommandText = "TPgetFileCloud";
        //    objCommand.CommandType = CommandType.StoredProcedure;

        //    objCommand.Parameters.AddWithValue("@accountID", accountID);
        //    myDS = myDB.GetDataSetUsingCmdObj(objCommand);
        //    DataRow fileCloud = myDS.Tables[0].Rows[0];

        //    if (fileCloud["fileCloud"] != DBNull.Value)
        //    {
        //        byteArray = (Byte[])fileCloud["fileCloud"];
        //        return mySerialization.DeserializeFromByteArray(byteArray);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //// add the user ID to the cloud database
        //[WebMethod]
        //public int createCloud(int accountID)
        //{
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandText = "TPcreateCloud"; 
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.Parameters.AddWithValue("@accountID", accountID);
        //    int returnValue = myDB.DoUpdateUsingCmdObj(objCommand);
        //    return returnValue;
        //}
    }
}
