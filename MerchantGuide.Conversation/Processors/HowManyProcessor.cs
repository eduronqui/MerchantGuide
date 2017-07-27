using MerchantGuide.Conversation.Attributes;
using MerchantGuide.Conversation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Processors
{
    [PhraseType(PhraseType.HowMany, RegexPatterns.HOW_MANY)]
    class HowManyProcessor : IPhraseProcessor
    {
        private IValuesStorage valuesStorage;

        public HowManyProcessor()
            : this(new ValuesStorage())
        {
        }

        public HowManyProcessor(IValuesStorage valuesStorage)
        {
            this.valuesStorage = valuesStorage;
        }

        public string Process(MatchCollection matchCollection)
        {
            return ProcessMatch(matchCollection);
        }

        public string Process(string phrase)
        {
            var match = Regex.Matches(phrase, RegexPatterns.HOW_MANY, RegexOptions.IgnoreCase);

            return ProcessMatch(match);
        }

        private string ProcessMatch(MatchCollection match)
        {
            var words = match[0].Groups[1].Value.Trim().Split(' ');

            var romanQty = String.Join("", words.Take(words.Length - 1).Select(n => valuesStorage.GetLiteral(n)));

            var qty = RomanNumeral.Converter.ConvertFromRomanNumeral(romanQty);

            var objectValue = valuesStorage.GetComputed(words.Last());

            var value = objectValue * qty;

            return $"{string.Join(" ", words)} is {value} Credits";
        }
    }
}
