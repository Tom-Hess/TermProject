using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace TermProjectLibrary
{
    public class Serialize
    {
        DBConnect myDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();


        // This function uses binary serialization to serialize an Object to a MemoryStream
        public MemoryStream SerializeToMemoryStream(Object objToSerialize)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, objToSerialize);
            return memoryStream;
        }

        // This function uses binary deserialization to reconstruct an Object from a MemoryStream
        public Object DeserializeFromMemoryStream(MemoryStream memoryStream)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            Object deserializedObject;
            memoryStream.Position = 0;
            deserializedObject = deserializer.Deserialize(memoryStream);
            return deserializedObject;
        }

        // This function uses binary serialization to serialize an Object to a Byte Array
        public Byte[] SerializeToByteArray(Object objToSerialize)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            Byte[] byteArray;
            serializer.Serialize(memoryStream, objToSerialize);
            byteArray = memoryStream.ToArray();
            return byteArray;
        }

        // This function uses binary deserialization to reconstruct an Object from a Byte Array
        public Object DeserializeFromByteArray(Byte[] byteArray)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Object deserializedObject;
            deserializedObject = deserializer.Deserialize(memoryStream);
            return deserializedObject;
        }

        public int writeCloud(Object fileCloud, int accountID)
        {
            Byte[] byteArray;
            SqlCommand objCommand = new SqlCommand();

            int returnValue;

            byteArray = SerializeToByteArray(fileCloud);
            //this updates cart that already exists
            objCommand.CommandText = "TPwriteCloud";
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@fileCloud", byteArray);
            objCommand.Parameters.AddWithValue("@accountID", accountID);
            returnValue = myDB.DoUpdateUsingCmdObj(objCommand);
            return returnValue;
        }

        //check if a cloud user already has cloud data
        public bool checkCloudExists(int accountID)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet myDS;

            objCommand.CommandText = "TPgetFileCloud";
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@accountID", accountID);
            myDS = myDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public int createCloud(int accountID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandText = "TPcreateCloud";
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@accountID", accountID);
            int returnValue = myDB.DoUpdateUsingCmdObj(objCommand);
            return returnValue;
        }

        //get a user's cloud data
        public Object getFileCloud(int accountID)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet myDS;
            Byte[] byteArray;

            objCommand.CommandText = "TPgetFileCloud";
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@accountID", accountID);
            myDS = myDB.GetDataSetUsingCmdObj(objCommand);
            DataRow fileCloud = myDS.Tables[0].Rows[0];

            if (fileCloud["fileCloud"] != DBNull.Value)
            {
                byteArray = (Byte[])fileCloud["fileCloud"];
                return DeserializeFromByteArray(byteArray);
            }
            else
            {
                return null;
            }
        }

        // add the user ID to the cloud database
        





    }
}
