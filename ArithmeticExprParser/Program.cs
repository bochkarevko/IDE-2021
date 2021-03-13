using System;

namespace ArithmeticExprParser
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter expression:");
            string input;
            while((input = Console.ReadLine()) != null && input != ""){
                try
                {
                    var expr = SimpleParser.Parse(input);
                    var dumpVisitor = new DumpVisitor();
                    expr.Accept(dumpVisitor);
                    Console.WriteLine("\t" + dumpVisitor);
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine("Parsing error:");
                    Console.WriteLine("\t" + exc.Message);
                }
                Console.WriteLine("Enter expression:");
            }
        }
    }
}