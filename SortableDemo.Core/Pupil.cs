using System;
using System.Collections.Generic;
using System.Text;

namespace SortableDemo.Core
{
    public class Pupil : IComparable
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public int CompareTo(object obj)
        {
            return this.LastName.CompareTo((obj as Pupil).LastName);
        }
    }
}