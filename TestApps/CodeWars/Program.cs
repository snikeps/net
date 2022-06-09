using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"true - {Scramblies.Scramble("rkqodlw", "world")}");
            Console.WriteLine($"true - {Scramblies.Scramble("cedewaraaossoqqyt", "codewars")}");
            Console.WriteLine($"false - {Scramblies.Scramble("katas", "steak")}");
            Console.WriteLine($"false - {Scramblies.Scramble("scriptjavx", "javascript")}");
            Console.WriteLine($"true - {Scramblies.Scramble("aabbcamaomsccdd", "commas")}");
        }

    }

    public class Scramblies
    {
        public static bool Scramble(string str1, string str2)
        {
            var letStat = str2.GroupBy(x => x).Select(x => new
            {
                letter = x.Key,
                count = x.Count()
            });

            foreach (var l in str2)
            {
                if (!str1.Contains(l) || str1.Where(x => x == l).Count() < letStat.Where(x => x.letter == l).First().count)
                    return false;
            }

            return true;
        }
    }
}
