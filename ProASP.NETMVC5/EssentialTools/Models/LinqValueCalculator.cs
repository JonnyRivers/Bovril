using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscounter m_discounter;

        public LinqValueCalculator(IDiscounter discounter)
        {
            m_discounter = discounter;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return m_discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}