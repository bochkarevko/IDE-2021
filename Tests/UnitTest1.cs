using System;
using System.Collections.Generic;
using NUnit.Framework;
using ArithmeticExprParser;

namespace Tests
{
    public class Tests
    {
        private readonly DumpVisitor _dump = new();
        private readonly DumpVisitor2 _dump2 = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DumpVisitorTest()
        {
            new BinaryExpression(new Literal("1"), new Literal("2"), "+").Accept(_dump);
            Assert.AreEqual("Binary(Literal(1)+Literal(2))", _dump.ToString());
            
            _dump.Reset();

            Assert.Pass();
        }

        private void RunSimpleParserTest(string expr)
        {
            SimpleParser.Parse(expr).Accept(_dump2);
            Assert.AreEqual(expr, _dump2.ToString());
            _dump2.Reset();
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
        
        public void PriorityTest1(char op1, char op2)
        {
            SimpleParser.Parse($"a{op1}b{op2}c").Accept(_dump);
            Assert.AreEqual($"Binary(Variable(a){op1}Binary(Variable(b){op2}Variable(c)))", _dump.ToString());
            _dump.Reset();
        }
        
        public void PriorityTest2(char op2, char op1)
        {
            SimpleParser.Parse($"a{op1}b{op2}c").Accept(_dump);
            Assert.AreEqual($"Binary(Binary(Variable(a){op1}Variable(b)){op2}Variable(c))", _dump.ToString());
            _dump.Reset();
        }
        
        public void PriorityTestParen(char op1, char op2)
        {
            SimpleParser.Parse($"a{op1}(b{op2}c)").Accept(_dump);
            Assert.AreEqual($"Binary(Variable(a){op1}Paren(Binary(Variable(b){op2}Variable(c))))", _dump.ToString());
            _dump.Reset();
            
            SimpleParser.Parse($"a{op2}(b{op1}c)").Accept(_dump);
            Assert.AreEqual($"Binary(Variable(a){op2}Paren(Binary(Variable(b){op1}Variable(c))))", _dump.ToString());
            _dump.Reset();
        }
        
        public void PriorityTest3(char op1, char op2)
        {
            SimpleParser.Parse($"a{op1}b{op2}c{op1}d").Accept(_dump);
            Assert.AreEqual($"Binary(Binary(Variable(a){op1}Binary(Variable(b){op2}Variable(c))){op1}Variable(d))", _dump.ToString());
            _dump.Reset();
        }

        [Test]
        public void PriorityTest()
        {
            var opsList = new List<(char, char)>
            {
                ('+', '*'),
                ('+', '/'),
                ('-', '*'),
                ('-', '/')
            };
            
            foreach (var (lowPriorityOp, highPriorityOp) in opsList)
            {
                PriorityTest1(lowPriorityOp, highPriorityOp);
                PriorityTest2(lowPriorityOp, highPriorityOp);
                PriorityTestParen(lowPriorityOp, highPriorityOp);
                PriorityTest3(lowPriorityOp, highPriorityOp);

            }


            Assert.Pass();
        }
    }
}