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
    public class VariableNode : Node
    {
        public string Name { get; set; }
        public VariableNode(string name)
        {
            Name = name;
        }
    }
    public class ValueNode<T> : Node
    {
        public T Value { get; set; }
        public ValueNode(T value)
        {
            Value = value;
        }
    }
}
