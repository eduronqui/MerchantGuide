using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class PhraseTypeAttribute : Attribute
    {
        public PhraseType PhraseType { get; private set; }

        public string Pattern { get; private set; }

        public PhraseTypeAttribute(PhraseType phraseType, string pattern = null)
        {
            PhraseType = phraseType;
            Pattern = pattern ?? string.Empty;
        }

        public bool Match(string input)
            => Regex.IsMatch(input, Pattern, RegexOptions.IgnoreCase);
    }
}
