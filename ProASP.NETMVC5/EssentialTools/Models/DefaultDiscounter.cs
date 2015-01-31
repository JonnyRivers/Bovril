using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class DefaultDiscounter : IDiscounter
    {
        private decimal m_rate;

        public DefaultDiscounter(decimal rate)
        {
            m_rate = rate;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return m_rate * total;
        }
    }
}