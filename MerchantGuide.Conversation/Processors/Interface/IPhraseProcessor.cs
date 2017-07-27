using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Processors
{
    interface IPhraseProcessor
    {
        string Process(string phrase);

        string Process(GroupCollection groups);
    }
}
