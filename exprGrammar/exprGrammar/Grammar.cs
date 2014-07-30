using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exprGrammar
{
    public partial class Grammar
    {
        string Flatten(IEnumerable<string> input)
        {
            var result = "";
            foreach (var item in input)
                result += item;
            return result;
        }
    }
}
