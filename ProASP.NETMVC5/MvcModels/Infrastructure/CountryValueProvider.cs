using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    public class CountryValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().Contains("country");
        }

        public ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                return new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
}