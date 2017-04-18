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
        DBConnect objDB = new DBConnect();
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

       

    }
}
