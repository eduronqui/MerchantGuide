using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Data
{
    interface IValuesStorage
    {
        void AddComputed(string name, float value);

        void AddLiteral(string name, string value);

        float GetComputed(string name);

        string GetLiteral(string name);
    }
}
