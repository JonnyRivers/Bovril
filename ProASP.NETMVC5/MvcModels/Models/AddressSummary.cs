using System;
using System.Web.Mvc;

using MvcModels.Infrastructure;

namespace MvcModels.Models
{
    [ModelBinder(typeof(AddressSummaryBinder))]
    public class AddressSummary
    {
        public String City { get; set; }
        public String Country { get; set; }
    }
}