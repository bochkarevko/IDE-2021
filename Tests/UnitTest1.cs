using System;
using NUnit.Framework;
using ArithmeticExprParser;

namespace Tests
{
    public class Tests
    {
        private readonly DumpVisitor2 _dump = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DumpVisitorTest()
        {
            var dumpVisitor = new DumpVisitor();
            new BinaryExpression(new Literal("1"), new Literal("2"), "+").Accept(dumpVisitor);
            Assert.AreEqual("Binary(Literal(1)+Literal(2))", dumpVisitor.ToString());

            Assert.Pass();
        }

        private void RunSimpleParserTest(string expr)
        {
            SimpleParser.Parse(expr).Accept(_dump);
            Assert.AreEqual(expr, _dump.ToString());
            _dump.Reset();
        }

        [Test]
        public void SimpleParserSmallTest()
        {
            RunSimpleParserTest("a+abc123");
            RunSimpleParserTest("a+b*c+d+e");
            RunSimpleParserTest("(a+b)*(c+d)");
            RunSimpleParserTest("((((((((((a))))))))))");
            RunSimpleParserTest("(((((a))))+((((b)))))");
            RunSimpleParserTest("(23+42)*(a-b)/((42-23)*(a+b))");
            RunSimpleParserTest("(hello+world)-test*(123+var-23*var2+var_3/v_a_r_2_3)");

            Assert.Pass();
        }

        [Test]
        public void SimpleParserBigTest()
        {
            var generator = new RandomExprGenerator();

            for (int i = 0; i < 1000; ++i)
            {
                RunSimpleParserTest(generator.RandomExpr());
            }

            Assert.Pass();
        }

        private void RunSimpleParserThrowsTest(string expr)
        {
            Assert.Throws<ArgumentException>( delegate
            {
                SimpleParser.Parse(expr);
            });
        }

        [Test]
        public void SimpleParserThrowTest()
        {
            RunSimpleParserThrowsTest("a+b)");
            RunSimpleParserThrowsTest("(a+b");
            RunSimpleParserThrowsTest("((((a)))))");

            RunSimpleParserThrowsTest("a++b");
            RunSimpleParserThrowsTest("+a+b");
            RunSimpleParserThrowsTest("a+b+");
            RunSimpleParserThrowsTest("+123a");
            RunSimpleParserThrowsTest("aaa+");

            RunSimpleParserThrowsTest("(a+b)(c+d)");
            RunSimpleParserThrowsTest("a+123abc");
            
            RunSimpleParserThrowsTest("a+b*c;23/42");
            RunSimpleParserThrowsTest("a+a'");

            Assert.Pass();
        }
    }
}