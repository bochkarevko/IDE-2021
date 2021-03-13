using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArithmeticExprParser
{
    public class SimpleParser
    {
        public static IExpression Parse(string text)
        {
            var parser = new ParserImpl(text);
            var result = parser.Run();

            if (parser.At != text.Length)
            {
                throw new ArgumentException("Expression is broken after pos " + parser.At + ": " +
                                            text.Substring(parser.At));
            }

            return result;
        }

        private readonly struct OperationStub
        {
            public char Op { get; }
            public int Priority { get; }
            public int Position { get; }

            public OperationStub(char op, int priority, int position)
            {
                Op = op;
                Priority = priority;
                Position = position;
            }
        }

        private class ParserImpl
        {
            private static readonly Regex VarName = new(@"[\d\w_]+");
            private static readonly Regex Num = new(@"[\d]+");

            private readonly Stack<IExpression> _expStack = new();
            private readonly Stack<OperationStub> _opStack = new();
            private readonly string _input;
            public int At { get; private set; }
            private bool _opState; // true if we expect op next, false otherwise
            private readonly bool _inParenthesis;

            private ParserImpl(string input, int from)
            {
                At = from;
                _input = input;
                _inParenthesis = true;
            }

            public ParserImpl(string input)
            {
                At = 0;
                _input = input;
                _inParenthesis = false;
            }

            private string GetVarName()
            {
                var m = VarName.Match(_input.Substring(At));
                At += m.Length;
                return m.Value;
            }

            private string GetNumber()
            {
                var m = Num.Match(_input.Substring(At));
                At += m.Length;
                return m.Value;
            }

            private void FoldTop()
            {
                try
                {
                    var secondOperand = _expStack.Pop();
                    var firstOperand = _expStack.Pop();
                    _expStack.Push(new BinaryExpression(firstOperand, secondOperand, _opStack.Pop().Op.ToString()));
                }
                catch (InvalidOperationException)
                {
                    var brokenOp = _opStack.Peek();
                    throw new ArgumentException("Not enough operands for operation '" + brokenOp.Op + "' at position " +
                                                brokenOp.Position);
                }
            }

            private void CompleteFold()
            {
                while (_opStack.Any())
                {
                    FoldTop();
                }
            }

            private void NextOp(OperationStub op)
            {
                if (!_opState)
                {
                    throw new ArgumentException("Got operation at pos " + At +
                                                " when literal or variable was expected");
                }

                while (_opStack.Any() && !(op.Priority > _opStack.Peek().Priority))
                {
                    FoldTop();
                }

                _opState = false;
                _opStack.Push(op);
                ++At;
            }

            private void NextNotOp()
            {
                if (_opState)
                {
                    throw new ArgumentException("Operation was expected at pos " + At);
                }

                _opState = true;
            }

            private void CheckClosingParenthesis(int at)
            {
                if (_input[at] != ')')
                {
                    throw new ArgumentException("No closing parenthesis for opening at pos " + At);
                }

                At = at + 1;
            }

            public IExpression Run()
            {
                while (At < _input.Length)
                {
                    var ch = _input[At];
                    switch (ch)
                    {
                        case '+':
                        case '-':
                            NextOp(new OperationStub(ch, 1, At));
                            break;
                        case '*':
                        case '/':
                            NextOp(new OperationStub(ch, 2, At));
                            break;
                        case '(':
                            NextNotOp();
                            var p = new ParserImpl(_input, At + 1);
                            _expStack.Push(new ParenExpression(p.Run()));
                            At = p.At;
                            break;
                        case ')':
                            if (!_inParenthesis)
                            {
                                throw new ArgumentException("Unexpected closing parenthesis at pos " + At);
                            }
                            ++At;
                            CompleteFold();
                            return _expStack.Peek();
                        case { } when char.IsDigit(ch):
                            NextNotOp();
                            _expStack.Push(new Literal(GetNumber()));
                            break;
                        case { } when char.IsLetter(ch):
                            NextNotOp();
                            _expStack.Push(new Variable(GetVarName()));
                            break;
                        case { } when char.IsWhiteSpace(ch):
                            // skip whitespace
                            ++At;
                            break;
                        default:
                            throw new ArgumentException("Illegal character: '" + ch + "' at pos " + At);
                    }
                }

                if (_inParenthesis)
                {
                    throw new ArgumentException("Missing closing parenthesis");
                }

                CompleteFold();
                return _expStack.Peek();
            }
        }
    }
}