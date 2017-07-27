using MerchantGuide.Conversation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MerchantGuide.Conversation.Processors
{
    [PhraseType(PhraseType.Unknown)]
    class UnknownPhraseTypeProcessor : IPhraseProcessor
    {
        private string unknown = "I have no idea what you are talking about";

        public string Process(GroupCollection groups)
            => this.unknown;

        public string Process(string phrase)
            => this.unknown;
    }
}
