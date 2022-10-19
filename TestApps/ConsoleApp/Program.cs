using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.IsPalindrome(15888851));
        }
    }
}

public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;

        if (x <= 9)
            return true;

        int pow = (int)Math.Log10(x);

        while(pow > 0)
        {
            int part1 = x % 10;
            int part2 = (int)(x / Math.Pow(10, pow));
            if (part1 != part2)
                return false;

            x %= (int)Math.Pow(10, pow);
            x /= 10;
            pow -= 2;
        }

        return true;
    }
}