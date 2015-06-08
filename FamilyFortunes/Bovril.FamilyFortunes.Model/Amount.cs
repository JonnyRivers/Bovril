using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.FamilyFortunes.Model
{
    public class Amount
    {
        private readonly decimal m_value;
        private readonly Currency m_currency;

        public decimal Value { get { return m_value; } }
        public Currency Unit { get { return m_currency; } }

        public Amount(decimal value, Currency currency)
        {
            m_value = value;
            m_currency = currency;
        }

        public static Amount operator +(Amount lhs, Amount rhs)
        {
            return new Amount(lhs.Value + CurrencyExchange.Convert(rhs.Value, lhs.Unit, rhs.Unit), lhs.Unit);
        }

        public static Amount operator -(Amount lhs, Amount rhs)
        {
            return new Amount(lhs.Value - CurrencyExchange.Convert(rhs.Value, lhs.Unit, rhs.Unit), lhs.Unit);
        }
    }
}
