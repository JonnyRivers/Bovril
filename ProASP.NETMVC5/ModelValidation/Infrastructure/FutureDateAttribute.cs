using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime? date = value as DateTime?;
            return date.HasValue && date > DateTime.Now;
        }
    }
}