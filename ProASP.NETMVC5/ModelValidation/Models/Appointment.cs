using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    // Useful if we are validating in the controller
    //public class Appointment
    //{
    //    public String ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    public DateTime Date { get; set; }

    //    public bool TermsAccepted { get; set; }
    //}

    // Validation via data annotations
    //[NoJoeOnMondays]
    //public class Appointment
    //{
    //    [Required]
    //    public String ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    //[Required(ErrorMessage="Please enter a date")]
    //    [FutureDate(ErrorMessage="Please enter a date in the future")]
    //    public DateTime Date { get; set; }

    //    //[Range(typeof(bool), "true", "true", ErrorMessage="You must accept the terms")]
    //    [MustBeTrue(ErrorMessage = "You must accept the terms")]
    //    public bool TermsAccepted { get; set; }
    //}

    // Here we peform validation in a member supplied method.  This can be aupplemented by the controller
    // for context specific validation, but validation here cannot be suppressed.
    //public class Appointment : IValidatableObject
    //{
    //    public String ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    public DateTime Date { get; set; }

    //    public bool TermsAccepted { get; set; }

    //    public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {
    //        List<ValidationResult> errors = new List<ValidationResult>();

    //        if (String.IsNullOrEmpty(ClientName))
    //        {
    //            errors.Add(new ValidationResult("Please enter your name", new String[] { "ClientName" }));
    //        }

    //        if (Date <= DateTime.Now)
    //        {
    //            errors.Add(new ValidationResult("Please enter a date in the future", new String[] { "Date" }));
    //        }

    //        if (errors.Count == 0 && ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
    //        {
    //            errors.Add(new ValidationResult("Joe cannot make appointments on Mondays"));
    //        }

    //        if (!TermsAccepted)
    //        {
    //            errors.Add(new ValidationResult("You must accept the terms", new String[] { "TermsAccepted" }));
    //        }

    //        return errors;
    //    }
    //}

    // Client side validation
    //public class Appointment
    //{
    //    [Required]
    //    [StringLength(10, MinimumLength=3)]
    //    public String ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    public DateTime Date { get; set; }

    //    public bool TermsAccepted { get; set; }
    //}

    // Client side validation
    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public String ClientName { get; set; }

        [DataType(DataType.Date)]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }
}