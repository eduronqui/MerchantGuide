using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuide.RomanNumeral.Validators
{
    public class RomanValidator
    {
        private const string ValidRomanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

        public static bool IsValid(string roman)
        {
            return Regex.IsMatch(roman, ValidRomanPattern);
        }
    }
}
