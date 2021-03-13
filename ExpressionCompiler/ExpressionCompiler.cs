using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using ArithmeticExprParser;

namespace ExpressionCompiler
{
    class ExpressionCompiler : IExpressionVisitor
    {
        private readonly List<string> _variablesList = new();
        private readonly AssemblyBuilder _assemblyBuilder;
        private readonly TypeBuilder _typeBuilder;
        private readonly MethodBuilder _eval;
        private readonly ILGenerator _evalIL;
        
        ExpressionCompiler(IExpression expression)
        {
            var assemblyName = new AssemblyName("CompiledExpression");
            _assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = _assemblyBuilder.DefineDynamicModule(assemblyName.Name ?? "??");
            _typeBuilder = moduleBuilder.DefineType("Evaluator", TypeAttributes.Public);

            var smth = _typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            
            var variablesCounter = new VariablesVisitor();
            expression.Accept(variablesCounter);
            _variablesList = variablesCounter.VariablesSet.ToList();

            var args = new Type[_variablesList.Count];
            for (var i = 0; i < args.Length; i++)
            {
                args[i] = typeof(int);
            }

            _eval = _typeBuilder.DefineMethod(  // Can be static btw
                "Eval",
                MethodAttributes.Public,
                typeof(int),
                args);

            _evalIL = _eval.GetILGenerator();

            expression.Accept(this);

            _evalIL.Emit(OpCodes.Ret);
        }

        public void Visit(Literal expression)
        {
            _evalIL.Emit(OpCodes.Ldc_I4, int.Parse(expression.Value));
        }

        public void Visit(Variable expression)
        {
            _evalIL.Emit(OpCodes.Ldarg, _variablesList.IndexOf(expression.Name) + 1);
        }

        public void Visit(BinaryExpression expression)
        {
            expression.FirstOperand.Accept(this);
            expression.SecondOperand.Accept(this);
            switch(expression.Operator)
            {
                    case "+":
                        _evalIL.Emit(OpCodes.Add);
                        break;
                    case "-":
                        _evalIL.Emit(OpCodes.Sub);
                        break;
                    case "*":
                        _evalIL.Emit(OpCodes.Mul);
                        break;
                    case "/":
                        _evalIL.Emit(OpCodes.Div);;
                        break;
                    default:
                        throw new ArgumentException("Illegal operation " + expression.Operator);
            }
        }

        public void Visit(ParenExpression expression)
        {
            expression.Operand.Accept(this);
        }

        static void Main()
        {
            var expr = new BinaryExpression(new Variable("a"), new Literal("2"), "/");
            var test = new ExpressionCompiler(expr);
            Type t = test._typeBuilder.CreateType();

            // Does not work
            // test._assemblyBuilder.Save("test.dll");

            // Because AssemblyBuilderAccess includes Run, the code can be
            // executed immediately. Start by getting reflection objects for
            // the method and the property.
            MethodInfo eval = t.GetMethod("Eval");
            Console.WriteLine(eval.GetParameters().Length);

            // Create an instance of MyDynamicType using the constructor
            // that specifies m_Number. The constructor is identified by
            // matching the types in the argument array. In this case,
            // the argument array is created on the fly. Display the
            // property value.
            object o = Activator.CreateInstance(t);
            object[] arguments = { 42 };
            Console.WriteLine("o.Eval(): {0}",
                eval.Invoke(o, arguments));
            
            /* This code produces the following output:
            o.Eval(): 21
             */
        }
    }
}