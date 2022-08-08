using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> openBrackets = new Stack<char>();
            bool areBalanced = false;

            foreach (char bracket in input)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    openBrackets.Push(bracket);
                }
                else if (bracket == '}' || bracket == ']' || bracket == ')')
                {
                    if (openBrackets.Count == 0)
                    {
                        areBalanced = false;
                        break;
                    }

                    char lastOpenBracket = openBrackets.Pop();

                    if (lastOpenBracket == '{' && bracket == '}')
                    {
                        areBalanced = true;
                    }
                    else if (lastOpenBracket == '[' && bracket == ']')
                    {
                        areBalanced = true;
                    }
                    else if (lastOpenBracket == '(' && bracket == ')')
                    {
                        areBalanced = true;
                    }
                    else
                    {
                        areBalanced = false;
                        break;
                    }
                }
                
            }
            if (areBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
