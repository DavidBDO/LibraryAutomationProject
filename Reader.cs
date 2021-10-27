using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQA
{
    public class Reader
    {
        public enum ReaderType
        {
            Kid, //The Reader is Kid
            Adult //The Reader is Adult
        }

        public ReaderType Type
        {
            get { return type; }
            set { type = value; }
        }

        private string firstName;
        private string lastName;
        private ReaderType type;

        public string FirstName
        {
            get { return firstName; }
        }


        public string LastName
        {
            get { return lastName; }
        }

        public Reader(string first_Name , string last_Name, ReaderType Type)
        {
            firstName = first_Name;
            lastName = last_Name;
            type = Type;
        }

    }
}
