using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing input file parameter. \n");
                Console.WriteLine("Usage:");
                Console.WriteLine("MerchantGuide.exe [file name]");
                return;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Cannot find specified file name. \n");
                return;
            }

            var lines = File.ReadAllLines(args[0]);
            if (lines == null || lines.Length == 0)
            {
                Console.WriteLine($"File is empty. \n");
                return;
            }

            var handler = new Conversation.Handler();
            
            foreach (var input in lines)
            {
                var answer = handler.Handle(input);

                if (string.IsNullOrWhiteSpace(answer))
                    continue;

                Console.WriteLine(answer);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
