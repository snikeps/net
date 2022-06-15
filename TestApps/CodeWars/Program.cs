using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"true: {Parentheses.ValidParentheses("()")}");
            Console.WriteLine($"false: {Parentheses.ValidParentheses(")(()))")}");
            Console.WriteLine($"false: {Parentheses.ValidParentheses("(")}");
            Console.WriteLine($"true: {Parentheses.ValidParentheses("()")}");
            Console.WriteLine($"true: {Parentheses.ValidParentheses("(())((()())())")}");
        }

    }

    public class Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            //Console.WriteLine(input);
            var filteredInput = input.Where(x => x == '(' || x == ')').ToList();

            if (!filteredInput.Any()
                || filteredInput.Count(x => x == '(') != filteredInput.Count(x => x == ')'))
            {
                return false;
            }

            for (int i = 1; i <= filteredInput.Count(); i++)
            {
                if (filteredInput.Take(i).Count(x => x == '(') < filteredInput.Take(i).Count(x => x == ')'))
                    return false;
            }

            return true;
        }
    }
}
