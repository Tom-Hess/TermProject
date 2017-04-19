using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TermProjectLibrary
{
    [Serializable]
    public class FileCloud
    {
        private ArrayList files = new ArrayList(); // arraylist of the current user's files

        public FileCloud()
        {

        }

        public ArrayList Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }
    }
}
