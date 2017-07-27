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

        public string Process(GroupCollection groups)
        {
            return ProcessMatch(groups);
        }

        public string Process(string phrase)
        {
            var match = Regex.Matches(phrase, RegexPatterns.ASSIGNMENT, RegexOptions.IgnoreCase);
            return ProcessMatch(match[0].Groups);
        }

        private string ProcessMatch(GroupCollection groups)
        {
            if (groups.Count < 3)
                throw new ArgumentException("groups");

            var name = groups[1].Value;
            var romanValue = groups[2].Value;

            if (!RomanNumeral.Validators.RomanValidator.IsValid(romanValue))
                throw new InvalidRomanNumeralException(romanValue);

            valuesStorage.AddLiteral(name, romanValue);

            return string.Empty;
        }
    }
}
