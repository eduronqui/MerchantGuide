using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Exceptions
{
    public class InvalidCreditValueException : Exception
    {
        public InvalidCreditValueException(string value)
            : base(value)
        {
        }
    }
}
