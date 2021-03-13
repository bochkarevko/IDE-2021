using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using ArithmeticExprParser;

namespace ExpressionCompiler
{
    class ExprCompilerImpl : IExpressionVisitor
    {
        private readonly List<string> _variablesList;
        private readonly TypeBuilder _typeBuilder;
        private readonly ILGenerator _evalCode;

        public ExprCompilerImpl(List<string> variables)
        {
            _variablesList = variables;
            var assemblyName = new AssemblyName("CompiledExpression");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name ?? "??");
            _typeBuilder = moduleBuilder.DefineType("Evaluator", TypeAttributes.Public);
            _typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);

            var args = new Type[_variablesList.Count];
            for (var i = 0; i < args.Length; i++)
            {
                args[i] = typeof(int);
            }

            var eval = _typeBuilder.DefineMethod( // Can be static btw
                "Eval",
                MethodAttributes.Public,
                typeof(int),
                args);

            _evalCode = eval.GetILGenerator();
        }

        public void Visit(Literal expression)
        {
            _evalCode.Emit(OpCodes.Ldc_I4, int.Parse(expression.Value));
        }

        public void Visit(Variable expression)
        {
            _evalCode.Emit(OpCodes.Ldarg, _variablesList.IndexOf(expression.Name) + 1);
        }

        public void Visit(BinaryExpression expression)
        {
            expression.FirstOperand.Accept(this);
            expression.SecondOperand.Accept(this);
            switch (expression.Operator)
            {
                case "+":
                    _evalCode.Emit(OpCodes.Add);
                    break;
                case "-":
                    _evalCode.Emit(OpCodes.Sub);
                    break;
                case "*":
                    _evalCode.Emit(OpCodes.Mul);
                    break;
                case "/":
                    _evalCode.Emit(OpCodes.Div);
                    ;
                    break;
                default:
                    throw new ArgumentException("Illegal operation " + expression.Operator);
            }
        }

        public void Visit(ParenExpression expression)
        {
            expression.Operand.Accept(this);
        }

        public Type GetCompiled()
        {
            _evalCode.Emit(OpCodes.Ret);
            return _typeBuilder.CreateType();
        }
    }

    public class ExprCompiler : IExpressionVisitor
    {
        private object _compiledExpr;
        private MethodInfo _eval;

        private void TrueVisit(IExpression expression)
        {
            var variablesCounter = new VariablesVisitor();
            expression.Accept(variablesCounter);
            var trueCompiler = new ExprCompilerImpl(variablesCounter.Variables);
            expression.Accept(trueCompiler);
            Type t = trueCompiler.GetCompiled();
            _compiledExpr = Activator.CreateInstance(t);
            _eval = t.GetMethod("Eval");
        }

        public void Visit(Literal expression)
        {
            TrueVisit(expression);
        }

        public void Visit(Variable expression)
        {
            TrueVisit(expression);
        }

        public void Visit(BinaryExpression expression)
        {
            TrueVisit(expression);
        }

        public void Visit(ParenExpression expression)
        {
            TrueVisit(expression);
        }

        public int Eval(object[] arguments)
        {
            return (int) _eval.Invoke(_compiledExpr, arguments);
        }

        static void Main()
        {
            var expr = new BinaryExpression(new Variable("a"), new Literal("2"), "/");
            var test = new ExprCompiler();
            expr.Accept(test);
            object[] arguments = {42};
            Console.WriteLine("Eval({0}): {1}", arguments, test.Eval(arguments));
        }
    }
}