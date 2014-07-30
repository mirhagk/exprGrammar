using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace exprGrammar
{
    class Program
    {
        static string parserFile = "./exprGrammar";
        static string testCode = "../../exprGrammar.txt";

        static void Main(string[] args)
        {
            var grammar = new Grammar();
            var parseTree = grammar.Parse(File.ReadAllText(testCode));

            Console.WriteLine(parseTree);

        }
    }
}
