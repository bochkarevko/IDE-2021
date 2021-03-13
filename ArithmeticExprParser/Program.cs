using System;

namespace ArithmeticExprParser
{
    internal static class Program
    {
        static void Main()
        {
            
            string input;
            while((input = Console.ReadLine()) != null && input != ""){
                Console.WriteLine("Enter expression:");
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
            }
        }
    }
}