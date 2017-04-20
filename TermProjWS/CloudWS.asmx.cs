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

        //adds the file's actual data to the database
        [WebMethod]
        public int addDownloadData (int accountID, byte[] data, int verification)
        {
            int returnID = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPaddDownloadData";
                myCommand.Parameters.AddWithValue("@accountID", accountID);
                myCommand.Parameters.AddWithValue("@data", data);

                myDB.DoUpdateUsingCmdObj(myCommand);

                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetMaxFileID";
                myDB.GetDataSetUsingCmdObj(myCommand);

                returnID = Convert.ToInt32(myDB.GetField("maxID", 0));
                return returnID;

            }else
            {
                return returnID;
            }
        }

        //returns the max file ID in the database
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

                returnID = Convert.ToInt32(myDB.GetField("maxID", 0));
                return returnID;

            }
            else
            {
                return 0;
            }
        }


        //returns the download data from the database
        [WebMethod]
        public byte[] getDownloadData (int fileID, Int64 fileLength, int verification)
        {
            byte[] data = new byte[fileLength];

            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPgetDownloadData";
                myCommand.Parameters.AddWithValue("@fileID", fileID);

                myDB.GetDataSetUsingCmdObj(myCommand);

                data = (byte[])myDB.GetField("fileData", 0);
            }
            return data;
        }

        [WebMethod]
        public int DeleteFile(int fileID, int verification)
        {
            int temp = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPdeleteFileP3";

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
        public int deleteAccount(int ID, int verification)
        {
            int flag = 0;
            if (verification == verificationToken)
            {
                myCommand.Parameters.Clear();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "TPdeleteAccountP3";

                SqlParameter myParameter = new SqlParameter("@ID", ID);
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
    }
}
