using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphTestbed.Models
{
    public class Person
    {
        public Person(String firstName, String lastName, DateTime dateOfBirth)
        {
            m_firstName = firstName;
            m_lastName = lastName;
            m_dateOfBirth = dateOfBirth;
        }

        public String FirstName { get { return m_firstName; } }
        public String LastName { get { return m_lastName; } }
        public DateTime DateOfBirth { get { return m_dateOfBirth; } }

        public int Age
        {
            get 
            {
                TimeSpan timeFromBirth = DateTime.Now - DateOfBirth;
                int age = (timeFromBirth.Days / 365);

                return age;
            }
        }

        private readonly String m_firstName;
        private readonly String m_lastName;
        private readonly DateTime m_dateOfBirth;
    }
}