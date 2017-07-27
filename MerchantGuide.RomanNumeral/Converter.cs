using MerchantGuide.RomanNumeral.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.RomanNumeral
{
    public class Converter
    {
        private static readonly Dictionary<char, int> romanMap;

        static Converter()
        {
            romanMap = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100},
                { 'D', 500 },
                { 'M', 1000 },
            };
        }

        public static int ConvertFromRomanNumeral(string romanNumeral)
        {
            if (!Validators.RomanValidator.IsValid(romanNumeral))
                throw new InvalidRomanNumeralException(romanNumeral);

            int converted = 0;
            for (int i = 0; i < romanNumeral.Length; i++)
            {
                int value = romanMap[romanNumeral[i]];

                if (romanNumeral.Length > i + 1 && value < romanMap[romanNumeral[i + 1]])
                    converted -= value;
                else
                    converted += value;
            }

            return converted;
        }
    }
}
