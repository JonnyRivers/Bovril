using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelperMethods.Models
{
    [DisplayName("New Person")]
    public partial class PersonMetaData
    {
        // This HiddenInput property prevents the property from being drawn
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        [Display(Name = "First")]
        public String FirstName { get; set; }

        [Display(Name = "Last")]
        public String LastName { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }
    }
}