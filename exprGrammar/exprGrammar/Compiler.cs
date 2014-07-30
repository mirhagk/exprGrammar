using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exprGrammar
{
    class Compiler
    {
        class Operator
        {
            public string op;
            public int prec;
        }


        public string Compile(string code) 
        {
            return CompileToJava(code);
        }

        Dictionary<string, Operator> binOperators = new Dictionary<string, Operator>()
        {
            {"AND", new Operator{op = "&&", prec = 20}},
            {"OR", new Operator{op = "||", prec = 21}},
            {"+", new Operator{op = "+", prec = 2}},
            {"*", new Operator{op = "*", prec = 1}},
            {"=", new Operator{op = "==", prec = 12}},
            {"<", new Operator{op = "<", prec = 10}},
            {">", new Operator{op = ">", prec = 10}},
        };


        public string CompileToJava(Node tree)
        {
            if (tree is ValueNode<int>)
            {
                return (tree as ValueNode<int>).Value.ToString();
            }
            if (tree is ValueNode<string>)
            {

            }

        }

        
    }
}
