using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exprGrammar
{
    public abstract class Node
    {
    }
    public class FunctionNode : Node
    {
        public string Function { get; set; }
        public IList<Node> Arguments { get; set; }
    }
    public class NumberNode : Node
    {
        public NumberNode(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
}
