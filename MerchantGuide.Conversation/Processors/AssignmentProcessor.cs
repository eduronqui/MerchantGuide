using MerchantGuide.Conversation.Attributes;
using MerchantGuide.Conversation.Data;
using MerchantGuide.RomanNumeral.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Processors
{
    [PhraseType(PhraseType.Assignment, RegexPatterns.ASSIGNMENT)]
    class AssignmentProcessor : IPhraseProcessor
    {
        private IValuesStorage valuesStorage;

        public AssignmentProcessor()
            : this(new ValuesStorage())
        {
        }

        public AssignmentProcessor(IValuesStorage valuesStorage)
        {
            this.valuesStorage = valuesStorage;
        }

        public string Process(MatchCollection matchCollection)
        {
            return ProcessMatch(matchCollection);
        }

        public string Process(string phrase)
        {
            var match = Regex.Matches(phrase, RegexPatterns.ASSIGNMENT, RegexOptions.IgnoreCase);

            return ProcessMatch(match);
        }

        private string ProcessMatch(MatchCollection match)
        {
            var name = match[0].Groups[1].Value;
            var romanValue = match[0].Groups[2].Value;

            if (!RomanNumeral.Validators.RomanValidator.IsValid(romanValue))
                throw new InvalidRomanNumeralException(romanValue);

            valuesStorage.AddLiteral(name, romanValue);

            return string.Empty;
        }
    }
}
