using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace PasLexer
{
    public class PasLexer
    {
        public static IList<IToken> Lex(string what)
        {
            var stream = CharStreams.fromString(what);
            var lexer = new Pascal(stream);
            var tokens = new BufferedTokenStream(lexer);
            tokens.Fill();
            return tokens.GetTokens();
        }
        
        public static void Main(string[] args)
        {
            const string input = "(* (* ... (* ... *) ... *) *) 1.15 1.1e-15 hello  $355FFA %01010 &1725 { { hello2 } } ";
            var tokens = Lex(input);
            foreach (var token in tokens)
            {
                Console.WriteLine(token.Text);
                // Console.WriteLine(token.Type);
            }
        }
    }
}