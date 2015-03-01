using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperMethods.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        public Role Role { get; set; }
    }
}