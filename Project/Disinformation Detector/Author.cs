using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        public int Credibility { get; set; }

        //public Author (string name, DateTime dateOfBirth)
        //{

        //}
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            return FirstName == (obj as Author).FirstName && LastName == (obj as Author).LastName;
        }
    }
}
