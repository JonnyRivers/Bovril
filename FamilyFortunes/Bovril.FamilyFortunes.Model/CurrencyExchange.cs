using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.FamilyFortunes.Model
{
    public static class CurrencyExchange
    {
        public static decimal Convert(decimal value, Currency sourceUnit, Currency destinationUnit)
        {
            if (sourceUnit == destinationUnit)
                return value;

            return value * GetRate(sourceUnit, destinationUnit);
        }

        private static decimal GetRate(Currency sourceUnit, Currency destinationUnit)
        {
            if (sourceUnit == destinationUnit)
                return 1;

            // TODO: make this sane
            if (sourceUnit == Currency.USD && destinationUnit == Currency.GBP)
                return 1 / s_exchangeRateGBPUSD;

            if (sourceUnit == Currency.GBP && destinationUnit == Currency.USD)
                return s_exchangeRateGBPUSD;

            throw new InvalidOperationException();
        }

        private static decimal s_exchangeRateGBPUSD = 0.654779M;
    }
}
