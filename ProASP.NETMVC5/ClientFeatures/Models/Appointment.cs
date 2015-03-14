using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientFeatures.Models
{
    public class Appointment
    {
        [Required]
        public String ClientName { get; set; }

        public bool TermsAccepted { get; set; }
    }
}