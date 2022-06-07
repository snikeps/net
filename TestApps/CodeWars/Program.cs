using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.IsPangram("The quick brown fox jumps over the lazy dog."));
            Console.WriteLine(Kata.IsPangram("The quick bron fox jumps over the lazy dog."));
        }

    }
    public static class Kata
    {
        public static bool IsPangram(string str)
        {
            if (str.ToLower().Where(l => l >= 'a' && l <= 'z').Distinct().Count() == 26)
                return true;

            return false;
        }
    }
}
