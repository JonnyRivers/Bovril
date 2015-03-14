using System;
using System.ComponentModel.DataAnnotations;

using ModelValidation.Models;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book appointments on Mondays";
        }
        public override bool IsValid(object value)
        {
            Appointment appointment = value as Appointment;
            if (appointment == null || String.IsNullOrEmpty(appointment.ClientName) || appointment.Date == null)
            {
                return true;
            }
            else
            {
                return !(appointment.ClientName == "Joe" && appointment.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}