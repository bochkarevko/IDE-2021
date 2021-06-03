using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace PasLexer
{
    public class PasLexer
    {
        public static void Main(string[] args)
        {
            String input = "(* (* ... (* ... *) ... *) *) 1.15 1.1e-15 hello  { { hello2 } } ";
            var stream = CharStreams.fromString(input);
            var lexer = new Pascal(stream);
            var tokens = new BufferedTokenStream(lexer);
            tokens.Fill();
            Console.WriteLine(tokens.GetTokens().Count);
            foreach (var token in tokens.GetTokens())
            {
                Console.WriteLine(token.Text);
                Console.WriteLine(lexer.Vocabulary.GetSymbolicName(token.Type));
            }
        }
    }
}