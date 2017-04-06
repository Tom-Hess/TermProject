using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectLibrary
{
    //class used in order to validate data entry
    public class Validation
    {
        int intNumber;
        double doubleNumber;
        long longNumber;
        public bool IsEmpty(string s)
        {
            if (String.IsNullOrEmpty(s))
                return true;

            return false;
        }
        public bool IsIntString(string s)
        {
            if (!Int32.TryParse(s, out intNumber))
                return false;

            return true;
        }
        public bool IsDoubleString(string s)
        {
            if (!double.TryParse(s, out doubleNumber))
                return false;

            return true;
        }

        public bool IsLongString(string s)
        {
            if (!long.TryParse(s, out longNumber))
                return false;

            return true;
        }

    }
}