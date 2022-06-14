using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputArray = new List<string> { "crazer", "carer", "racar", "caers", "racer" };
            foreach (string arg in Kata.Anagrams("racer", inputArray))
            {
                Console.WriteLine(arg);
            }
        }

    }

    public static class Kata
    {
        public static List<string> Anagrams(string word, List<string> words)
        {
            return words.Where(x => x.OrderBy(y => y).SequenceEqual(word.OrderBy(y => y))).ToList();
        }
    }
}
