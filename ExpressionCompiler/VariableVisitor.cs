using System.Collections.Generic;
using ArithmeticExprParser;
using BinaryExpression = ArithmeticExprParser.BinaryExpression;

namespace ExpressionCompiler
{
    public class VariablesVisitor : IExpressionVisitor
    {
        public readonly List<string> Variables = new();

        public void Visit(Literal expression)
        {
        }

        public void Visit(Variable expression)
        {
            if (!Variables.Contains(expression.Name))
            {
                Variables.Add(expression.Name);
            }
        }

        public void Visit(BinaryExpression expression)
        {
            expression.FirstOperand.Accept(this);
            expression.SecondOperand.Accept(this);
        }

        public void Visit(ParenExpression expression)
        {
            expression.Operand.Accept(this);
        }
    }
}