using System;

namespace SomeoneSendHelp
{
    class Program
    {
        static void Main(string[] args)
        { 
            while (true)
            {
                Console.Write("$ ");
                string input = Console.ReadLine();

                if (input == "#exit")
                    Environment.Exit(0);

                Lexer l = new Lexer(input);
                Token[] tokens = l.MakeTokens();

                foreach (Token t in tokens)
                {
                    if (t.Type == TokenTypes.BadToken)
                        Utilities.WriteColor(ConsoleColor.Red, t);
                    else
                        Utilities.WriteColor(ConsoleColor.Green, t);
                }
            }
        }
    }
}
