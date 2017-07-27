using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Tests.Conversation.Mock
{
    class ValuesStorageMock : MerchantGuide.Conversation.Data.IValuesStorage
    {
        public Dictionary<string, float> ComputedValues { get; private set; }

        public Dictionary<string, string> LiteralValues { get; private set; }

        public ValuesStorageMock()
        {
            ComputedValues = new Dictionary<string, float>();
            LiteralValues = new Dictionary<string, string>();
        }

        public void AddComputed(string name, float value)
        {
            this.ComputedValues.Add(name, value);
        }

        public void AddLiteral(string name, string value)
        {
            this.LiteralValues.Add(name, value);
        }

        public float GetComputed(string name)
        {
            return this.ComputedValues[name];
        }

        public string GetLiteral(string name)
        {
            return this.LiteralValues[name];
        }
    }
}
