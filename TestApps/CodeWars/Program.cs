using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.IsInteresting(98, new List<int>() { 1337, 256 }));
        }

    }

    public static class Kata
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            if (number < 98)
                return 0;

            if (CheckInput(number, awesomePhrases))
                return 2;

            if (CheckInput(number + 1, awesomePhrases)
                || CheckInput(number + 2, awesomePhrases))
                return 1;

            return 0;
        }

        private static bool CheckInput(int number, List<int> awesomePhrases)
        {
            string num = number.ToString();

            if (num.Length < 3)
                return false;

            // The digits match one of the values in the awesomePhrases array
            if (awesomePhrases.Any(x => x == number))
                return true;

            // Any digit followed by all zeros
            if (number % (Math.Pow(10, num.Length - 1)) == 0)
                return true;

            // Every digit is the same number
            if (num.All(x => x == num[0]))
                return true;

            // The digits are a palindrome
            if (num.Take(num.Length / 2).SequenceEqual(num.TakeLast(num.Length / 2).Reverse()))
                return true;

            // The digits are sequential, incementing / decrementing
            var num1 = num.Skip(1).Select(x => (Convert.ToInt32(x) + 2) % 10);
            var num2 = num.SkipLast(1).Select(x => (Convert.ToInt32(x) + 2) % 10);

            if (num1.SequenceEqual(num2.Select(x => ((x - 1) % 10)))
                || num1.SequenceEqual(num2.Select(x => ((x + 1) % 10))))
                return true;

            return false;
        }
    }
}
