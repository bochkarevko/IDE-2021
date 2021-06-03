using System;
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

        [Test]
        public void FirstTest()
        {
            var size = 10;
            var inp = PascalGen.Gen(size);
            var res = PasLexer.PasLexer.Lex(inp);
            Assert.AreEqual(size * 2 + 1, res.Count); // + 1 for EOF
        }
    }
}