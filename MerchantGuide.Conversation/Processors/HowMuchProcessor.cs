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
    [PhraseType(PhraseType.HowMuch, RegexPatterns.HOW_MUCH)]
    class HowMuchProcessor : IPhraseProcessor
    {
        private IValuesStorage valuesStorage;

        public HowMuchProcessor()
            : this(new ValuesStorage())
        {
        }

        public HowMuchProcessor(IValuesStorage valuesStorage)
        {
            this.valuesStorage = valuesStorage;
        }

        public string Process(MatchCollection matchCollection)
        {
            return ProcessMatch(matchCollection);
        }

        public string Process(string phrase)
        {
            var match = Regex.Matches(phrase, RegexPatterns.HOW_MUCH, RegexOptions.IgnoreCase);

            return ProcessMatch(match);
        }

        private string ProcessMatch(MatchCollection match)
        {
            var words = match[0].Groups[1].Value.Trim().Split(' ');

            var romanValue = String.Join("",
                            words.Select(p => valuesStorage.GetLiteral(p)));

            var value = RomanNumeral.Converter.ConvertFromRomanNumeral(romanValue);

            return $"{String.Join(" ", words)} is {value}";
        }
    }
}
