using System;
using System.ComponentModel.DataAnnotations;

namespace HelperMethods.Models
{
    // rather than clutter this core type with lots of Mvc specific annotations, we define those elsewhere
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
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