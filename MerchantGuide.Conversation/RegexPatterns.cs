using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation
{
    class RegexPatterns
    {
        public const string HOW_MANY = @"^how many credits is ([a-z\s]+)\?$";

        public const string HOW_MUCH = @"^how much is ([a-z\s]+)\?$";

        public const string ASSIGNMENT = "^([a-z)]+) is ([IVXLCDM]+)$";

        public const string CREDIT = @"^([a-z\s]*) is ([0-9]+) credits$";
    }
}
