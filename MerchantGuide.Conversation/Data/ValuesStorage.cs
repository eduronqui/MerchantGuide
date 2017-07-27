using MerchantGuide.Conversation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation.Data
{
    class ValuesStorage : IValuesStorage
    {
        private static Dictionary<string, float> computedValues;

        private static Dictionary<string, string> literalValues;

        static ValuesStorage()
        {
            computedValues = new Dictionary<string, float>();
            literalValues = new Dictionary<string, string>();
        }

        public void AddComputed(string name, float value)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            var _name = name.ToLowerInvariant();

            if (computedValues.ContainsKey(_name))
                computedValues[_name] = value;
            else
                computedValues.Add(_name, value);
        }

        public void AddLiteral(string name, string value)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            var _name = name.ToLowerInvariant();

            if (literalValues.ContainsKey(_name))
                literalValues[_name] = value;
            else
                literalValues.Add(_name, value);
        }

        public float GetComputed(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            var _name = name.ToLowerInvariant();

            if (!computedValues.ContainsKey(_name))
                throw new UnknownWordException(name);

            return computedValues[_name];
        }

        public string GetLiteral(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            var _name = name.ToLowerInvariant();

            if (!literalValues.ContainsKey(_name))
                throw new UnknownWordException(name);

            return literalValues[_name];
        }
    }
}
