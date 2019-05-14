using System;
using System.Diagnostics;
using lab03.PIIntegration;
using lab03.CriticalSection;

namespace lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = true;
            foreach (var arg in args)
            {
                int number;
                success = Int32.TryParse(arg, out number);
            }

            if (args.Length != 3 || !success)
            {
                Console.WriteLine("Wrong arguments");
                Console.WriteLine("Usage: <program.exe> <iterationNumber> <timeout> <сount>");
                return;
            }
            else
            {
                int iterationNumber = Convert.ToInt32(args[0]);
                int timeout = Convert.ToInt32(args[1]);
                int count = Convert.ToInt32(args[2]);

                Process(iterationNumber, timeout, count, CSType.Enter, "Enter");
                Process(iterationNumber, timeout, count, CSType.TryEnter, "TryEnter");
            }
        }

        private static void Process(int iterationNumber, int timeout, int count, CSType csType, string typeStr)
        {
            ThreadIntegration integration = new ThreadIntegration(iterationNumber, timeout, count, csType);
            Stopwatch watch = Stopwatch.StartNew();
            double pi = integration.Integrate();
            watch.Stop();

            Console.WriteLine("PI: " + pi);
            Console.WriteLine("TIME: " + watch.ElapsedMilliseconds);
            Console.WriteLine("TYPE: " + typeStr);
            Console.WriteLine("---------------------");
        }
    }
}
