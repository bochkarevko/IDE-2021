using System;
using System.Collections.Generic;
using System.Linq;
using ArithmeticExprParser;
using BinaryExpression = ArithmeticExprParser.BinaryExpression;

namespace ExpressionCompiler
{
    public class VariablesVisitor : IExpressionVisitor
    {
        public readonly SortedSet<string> VariablesSet = new();
        public void Visit(Literal expression)
        {
        }

        public void Visit(Variable expression)
        {
            VariablesSet.Add(expression.Name);
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
        // private readonly Dictionary<string, int> _variables;
        // private readonly IExpression _expr;
        // private int _result = 0;
        //
        // public EvaluateVisitor(IExpression expr, Dictionary<string, int> variables)
        // {
        //     _expr = expr;
        //     _variables = variables;
        // }
        //
        // public int Eval(int[] valuesList)
        // {
        //     foreach (var (varValue, varName) in valuesList.Zip(_variables.Keys))
        //     {
        //         _variables[varName] = varValue;
        //     }
        //     _expr.Accept(this);
        //     return _result;
        // }
        //
        // public void Visit(Literal expression)
        // {
        //     _result = int.Parse(expression.Value);
        // }
        //
        // public void Visit(Variable expression)
        // {
        //     _result = _variables[expression.Name];
        // }
        //
        // public void Visit(BinaryExpression expression)
        // {
        //     expression.FirstOperand.Accept(this);
        //     var result1 = _result;
        //     expression.SecondOperand.Accept(this);
        //     var result2 = _result;
        //     switch (expression.Operator)
        //     {
        //         case "+":
        //             _result = result1 + result2;
        //             break;
        //         case "-":
        //             _result = result1 - result2;
        //             break;
        //         case "*":
        //             _result = result1 * result2;
        //             break;
        //         case "/":
        //             _result = result1 / result2;
        //             break;
        //         default:
        //             throw new ArgumentException("Illegal operation " + expression.Operator);
        //     }
        // }
        //
        // public void Visit(ParenExpression expression)
        // {
        //     expression.Operand.Accept(this);
        // }
    }
}