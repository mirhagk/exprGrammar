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
        string parserFile = "./exprGrammar";
        string testCode = "./exprGrammar.txt";

        static void Main(string[] args)
        {
            var grammar = new Grammar();
            grammar.Parse("");

            
            Console.WriteLine(Compiler.Compile(grammar.parse(File.ReadAllText(testCode))));

        }
    }
}
