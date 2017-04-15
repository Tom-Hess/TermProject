using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjWS
{
    public class Person
    {
        //string email;
        //string password;
        //string name;
        //int accountType; //admin = 1, user = 0
        //double storageCapacity;

        //public Person ()
        //{

        //}

        //public Person(string Email, string Password, string Name, int AccountType, double StorageCapacity)
        //{
        //    this.email = Email;
        //    this.password = Password;
        //    this.name = Name;
        //    this.accountType = AccountType;
        //    this.storageCapacity = StorageCapacity;
        //}

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int AccountType { get; set; }

        public Int64 StorageSpace { get; set; }

        public Int64 StorageUsed { get; set; }
    }
}
