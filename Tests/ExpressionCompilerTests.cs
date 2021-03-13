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
            var expr = new BinaryExpression(new Variable("a"), new Literal("2"), "*");
            var test = new ExprCompiler();
            expr.Accept(test);

            object[] arguments1 = {21};
            Assert.AreEqual(42, test.Eval(arguments1));

            object[] arguments2 = {2};
            Assert.AreEqual(4, test.Eval(arguments2));

            object[] arguments3 = {151};
            Assert.AreEqual(302, test.Eval(arguments3));

            Assert.Pass();
        }
    }
}