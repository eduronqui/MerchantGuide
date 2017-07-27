using MerchantGuide.Conversation.Attributes;
using MerchantGuide.Conversation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MerchantGuide.Conversation.Processors
{
    [PhraseType(PhraseType.CreditAssignment, RegexPatterns.CREDIT)]
    class CreditAssignmentProcessor : IPhraseProcessor
    {
        private IValuesStorage valuesStorage;

        public CreditAssignmentProcessor()
            : this(new ValuesStorage())
        {
        }

        public CreditAssignmentProcessor(IValuesStorage valuesStorage)
        {
            this.valuesStorage = valuesStorage;
        }

        public string Process(MatchCollection matchCollection)
        {
            return ProcessMatch(matchCollection);
        }

        public string Process(string phrase)
        {
            var match = Regex.Matches(phrase, RegexPatterns.CREDIT, RegexOptions.IgnoreCase);
            return ProcessMatch(match);
        }

        private string ProcessMatch(MatchCollection match)
        {
            var words = match[0].Groups[1].Value.Split(' ');

            var credits = match[0].Groups[2].Value;

            var romanValue = String.Join("", words.Take(words.Length - 1).Select(n => valuesStorage.GetLiteral(n)));

            var value = RomanNumeral.Converter.ConvertFromRomanNumeral(romanValue);

            var valueOfOne = float.Parse(credits) / value;

            valuesStorage.AddComputed(words.Last(), valueOfOne);

            return string.Empty;
        }
    }
}
