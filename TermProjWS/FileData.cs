using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectLibrary
{
    [Serializable]
    public class FileData
    {
        int fileID;
        string email;
        DateTime timestamp;
        byte[] data;
        Int64 length;
        string title;
        string type;
        int accountID;
        string imagePath;
        string extension;

        //empty constructor
        public FileData()
        {

        }

        //with Data
        public FileData(int fileID, string email, DateTime timestamp, byte[] data, 
            Int64 length, string title, string type, int accountID, string imagePath, string extension)
        {
            this.fileID = fileID;
            this.email = email;
            this.timestamp = timestamp;
            this.data = data;
            this.length = length;
            this.title = title;
            this.type = type;
            this.accountID = accountID;
            this.imagePath = imagePath;
            this.extension = extension;
        }

        //with no Data
        public FileData(int fileID, string email, DateTime timestamp, 
            Int64 length, string title, string type, int accountID, string imagePath, string extension)
        {
            this.fileID = fileID;
            this.email = email;
            this.timestamp = timestamp;
            this.length = length;
            this.title = title;
            this.type = type;
            this.accountID = accountID;
            this.imagePath = imagePath;
            this.extension = extension;
        }

        public int FileID
        {
            get { return this.fileID; }
            set { fileID = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public DateTime Timestamp
        {
            get { return this.timestamp; }
            set { this.timestamp = value; }
        }

        public byte[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Int64 Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public int AccountID
        {
            get { return this.accountID; }
            set { this.accountID = value; }
        }
        public string ImagePath
        {
            get { return this.imagePath; }
            set { this.imagePath = value; }
        }
        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }

    }
}
