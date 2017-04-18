using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectLibrary
{
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

        public int FileID { get; set; }
        public string Email { get; set; }
        public DateTime Timestamp { get; set; }
        public byte[] Data { get; set; }
        public Int64 Length { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int AccountID { get; set; }
        public string ImagePath { get; set; }
        public string Extension { get; set; }
        
    }
}
