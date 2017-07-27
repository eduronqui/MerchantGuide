using MerchantGuide.Conversation.Attributes;
using MerchantGuide.Conversation.Data;
using MerchantGuide.Conversation.Exceptions;
using MerchantGuide.Conversation.Processors;
using MerchantGuide.RomanNumeral.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuide.Conversation
{
    public class Handler
    {
        public string Handle(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return String.Empty;

            try
            {
                var phrase = input.Trim();
                var processor = GetPhraseProcessor(phrase);

                var attr = processor.GetType().GetCustomAttribute<PhraseTypeAttribute>();
                var match = Regex.Matches(phrase, attr.Pattern, RegexOptions.IgnoreCase);

                return processor.Process(match);
            }
            catch (UnknownWordException ex)
            {
                return $"I don't now what '{ex.Message}' means";
            }
            catch (InvalidRomanNumeralException ex)
            {
                return $"{ex.Message} is not a real number";
            }
            catch (Exception)
            {
                return "Ops, something really wrong has happened";
            }
        }

        private IPhraseProcessor GetPhraseProcessor(string phrase)
        {
            var processorType = Assembly.GetExecutingAssembly().GetTypes()
                                 .Where(t => typeof(IPhraseProcessor).IsAssignableFrom(t)
                                    && t.IsClass && !t.IsAbstract
                                    && t.GetCustomAttribute<PhraseTypeAttribute>().Match(phrase))
                                .FirstOrDefault();

            if (processorType == null)
                return new UnknownPhraseTypeProcessor();

            return (IPhraseProcessor)Activator.CreateInstance(processorType);
        }
    }
}
