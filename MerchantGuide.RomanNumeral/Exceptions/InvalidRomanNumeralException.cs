using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.RomanNumeral.Exceptions
{
    public class InvalidRomanNumeralException : Exception
    {
        public InvalidRomanNumeralException(string romanNumeral)
            : base(romanNumeral)
        {
        }
    }
}
