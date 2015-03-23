using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxMe.Models
{
    public class IncomeAndDeductions
    {
        public decimal GrossAnnualIncome { get; set; }

        public decimal TotalDeductions { get; set; }

        public State State { get; set; }
    }
}