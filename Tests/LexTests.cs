using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using NUnit.Framework;
using PasLexer;

namespace Tests
{
    public class LexTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static void CheckSize(int inSize, IList<IToken> tokens)
        {
            Assert.AreEqual(inSize * 2 + 1, tokens.Count);
        }

        private static void CheckTokens(int expectedType, IList<IToken> tokens)
        {
            for (var i = 0; i < tokens.Count - 1; ++i) // last token is EOF
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(expectedType, tokens[i].Type);
                }
                else // every other token is Whitespace
                {
                    Assert.AreEqual(Pascal.WHITESPACE, tokens[i].Type);
                }
            }
        }

        [Test]
        public void BaseTest()
        {
            const string comment1 = "(* huh(* { nested comment} wow*) *)";
            const string number1 = "&123";
            const string number2 = "-23.42e+666";
            const string charstr = "'meh'";
            const string ident = "hello";
            const string number3 = "%10101";
            const string number4 = "$FA13";
            const string comment2 = "{(*(hmm)*)}";
            string[] arr = {comment1, number1, number2, charstr, ident, number3, number4, comment2};
            int[] check =
            {
                Pascal.COMMENT, Pascal.WHITESPACE, Pascal.NUMBER, Pascal.WHITESPACE, Pascal.NUMBER,
                Pascal.WHITESPACE, Pascal.CHARACTERSTRING,  Pascal.WHITESPACE, Pascal.IDENTIFIER, Pascal.WHITESPACE, 
                Pascal.NUMBER, Pascal.WHITESPACE, Pascal.NUMBER, Pascal.WHITESPACE, Pascal.COMMENT, Pascal.Eof
            };
            var pascal = String.Join(' ', arr);
            var res = PasLexer.PasLexer.Lex(pascal);
            Assert.AreEqual(8 * 2, res.Count);

            var at = 0;
            for (var i = 0; i < res.Count; ++i)
            {
                var token = res[i];
                Assert.AreEqual(check[i], token.Type);
                Assert.AreEqual(at, token.StartIndex);
                if (i % 2 == 0)
                {
                    Assert.AreEqual(arr[i / 2], token.Text);
                    at += arr[i / 2].Length;
                }
                else if (token.Type != Pascal.Eof)
                {
                    at += 1;
                }
                Assert.AreEqual(at - 1, res[i].StopIndex);
            }
        }

        [Test]
        public void NumbersTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                var size = 10;
                var numbers = PascalGen.Numbers(size);
                var tokens = PasLexer.PasLexer.Lex(numbers);
                CheckSize(size, tokens);
                CheckTokens(Pascal.NUMBER, tokens);
            }
        }

        [Test]
        public void CommentsTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                var size = 10;
                var numbers = PascalGen.Comments(size);
                var tokens = PasLexer.PasLexer.Lex(numbers);
                CheckSize(size, tokens);
                CheckTokens(Pascal.COMMENT, tokens);
            }
        }

        [Test]
        public void CharStrTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                var size = 10;
                var numbers = PascalGen.CharStrings(size);
                var tokens = PasLexer.PasLexer.Lex(numbers);
                CheckSize(size, tokens);
                CheckTokens(Pascal.CHARACTERSTRING, tokens);
            }
        }

        [Test]
        public void IdentTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                var size = 10;
                var numbers = PascalGen.Identifiers(size);
                var tokens = PasLexer.PasLexer.Lex(numbers);
                CheckSize(size, tokens);
                CheckTokens(Pascal.IDENTIFIER, tokens);
            }
        }
    }
}