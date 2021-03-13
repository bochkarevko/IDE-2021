using System.Text;

namespace ArithmeticExprParser
{
    public class DumpVisitor2 : IExpressionVisitor
    {
        private readonly StringBuilder _myBuilder;

        public DumpVisitor2()
        {
            _myBuilder = new StringBuilder();
        }

        public void Visit(Literal expression)
        {
            _myBuilder.Append(expression.Value);
        }

        public void Visit(Variable expression)
        {
            _myBuilder.Append(expression.Name);
        }

        public void Visit(BinaryExpression expression)
        {
            expression.FirstOperand.Accept(this);
            _myBuilder.Append(expression.Operator);
            expression.SecondOperand.Accept(this);
        }

        public void Visit(ParenExpression expression)
        {
            _myBuilder.Append("(");
            expression.Operand.Accept(this);
            _myBuilder.Append(")");
        }

        public override string ToString()
        {
            return _myBuilder.ToString();
        }

        public void Reset()
        {
            _myBuilder.Clear();
        }
    }
}