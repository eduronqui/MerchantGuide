using MerchantGuide.Conversation.Attributes;
using MerchantGuide.Conversation.Data;
using MerchantGuide.Conversation.Exceptions;
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

        public string Process(GroupCollection groups)
        {
            return ProcessMatch(groups);
        }

        public string Process(string phrase)
        {
            var match = Regex.Matches(phrase, RegexPatterns.CREDIT, RegexOptions.IgnoreCase);
            return ProcessMatch(match[0].Groups);
        }

        private string ProcessMatch(GroupCollection groups)
        {
            if (groups.Count < 3)
                throw new ArgumentException("groups");

            var words = groups[1].Value.Split(' ');
            var credits = groups[2].Value;

            var romanValue = String.Join("", words.Take(words.Length - 1).Select(n => valuesStorage.GetLiteral(n)));

            var value = RomanNumeral.Converter.ConvertFromRomanNumeral(romanValue);

            float fcredit = 0;
            if (!float.TryParse(credits, out fcredit))
                throw new InvalidCreditValueException(credits);

            var valueOfOne = float.Parse(credits) / value;

            valuesStorage.AddComputed(words.Last(), valueOfOne);

            return string.Empty;
        }
    }
}
