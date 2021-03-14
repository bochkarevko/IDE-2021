using System;
using NUnit.Framework;
using ArithmeticExprParser;
using ExpressionCompiler;

namespace Tests
{
    public class ExpressionCompilerTests
    {
        private readonly DumpVisitor2 _dump = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IExpression expr = new ParenExpression(new BinaryExpression(new Variable("z"), new Literal("2"), "+"));
            var test = new ExprCompiler();
            expr.Accept(test);
            // (z + 2)
            Assert.AreEqual(42, test.Eval(new object[]{40}));
            Assert.AreEqual(7, test.Eval(new object[]{5}));
            Assert.AreEqual(668, test.Eval(new object[]{666}));
            
            expr = new ParenExpression(new BinaryExpression(new Variable("y"), expr, "*"));
            expr.Accept(test);
            // (y * (z + 2))
            Assert.AreEqual(16, test.Eval(new object[]{4, 2}));
            Assert.AreEqual(4, test.Eval(new object[]{2, 0}));
            Assert.AreEqual(0, test.Eval(new object[]{0, 2}));
            Assert.AreEqual(10000, test.Eval(new object[]{100, 98}));
            
            expr = new BinaryExpression(expr, new Variable("x"), "-");
            expr.Accept(test);
            // (y * (z + 2)) - x | Eval(int y, int z, int x)
            Assert.AreEqual(11, test.Eval(new object[]{2, 4, 1}));
            Assert.AreEqual(4, test.Eval(new object[]{2, 0, 0}));
            Assert.AreEqual(-10, test.Eval(new object[]{10, 17, 200}));
            
            expr = new BinaryExpression(new ParenExpression(expr), new Literal("4"), "/");
            expr.Accept(test);
            // ((y * (z + 2)) - x) / 4 | Eval(int y, int z, int x)
            Assert.AreEqual(3, test.Eval(new object[]{2, 4, 0}));
            Assert.AreEqual(1, test.Eval(new object[]{2, 0, 0}));
            Assert.AreEqual(9, test.Eval(new object[]{10, 2, 4}));
            
            expr = new BinaryExpression(new ParenExpression(expr), new Variable("z"), "+");
            expr.Accept(test);
            // (((y * (z + 2)) - x) / 4) + z | Eval(int y, int z, int x)
            Assert.AreEqual(7, test.Eval(new object[]{2, 4, 0}));
            Assert.AreEqual(1, test.Eval(new object[]{2, 0, 0}));
            Assert.AreEqual(11, test.Eval(new object[]{10, 2, 4}));

            Assert.Pass();
        }

        private int test2formula(object[] vars)
        {
            // 0 - a, 1 - b, 2 - c, 3 - d, 4 - e 
            return (int)vars[0] * 2 + (int)vars[1] * (int)vars[2] + 10 + (int)vars[3] * ((int)vars[4] - (int)vars[0]);
        }
        
        [Test]
        public void Test2()
        {
            // a * 2 + b * c + 10 + d * (e - a)
            IExpression expr = new BinaryExpression(
                new BinaryExpression(
                    new BinaryExpression(
                        new Variable("a"), 
                        new Literal("2"), 
                        "*"), 
                    new BinaryExpression(
                        new Variable("b"), 
                        new Variable("c"), 
                        "*"), 
                    "+"), 
                new BinaryExpression(
                    new Literal("10"), 
                    new BinaryExpression(
                        new Variable("d"), 
                        new BinaryExpression(
                            new Variable("e"), 
                            new Variable("a"), 
                            "-"), 
                        "*"), 
                    "+"), 
                "+");
            var test = new ExprCompiler();
            expr.Accept(test);
            Random random = new Random();
            
            // Eval(int a, int b, int c, int d, int e)
            for (int i = 0; i < 1000; ++i)
            {
                object[] vars = new object[]
                {
                    random.Next(-100, 100), random.Next(-100, 100), random.Next(-100, 100), random.Next(-100, 100),
                    random.Next(-100, 100)
                };
                Assert.AreEqual(test2formula(vars), test.Eval(vars));

            }

            Assert.Pass();
        }
    }
}