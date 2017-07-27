using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Exceptions
{
    public class UnknownWordException : Exception
    {
        public UnknownWordException(string word)
            : base(word)
        {
        }
    }
}
