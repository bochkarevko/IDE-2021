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
            const string input = "(* look at this (* { a nested comment} wow *) *) &123 -23.42e+666 'meh' hello %10101 $FA13";
            var tokens = Lex(input);
            foreach (var token in tokens)
            {
                Console.WriteLine(token.Text);
                // Console.WriteLine(token.Type);
            }
        }
    }
}