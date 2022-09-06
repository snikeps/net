using System;
using System.Linq;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsPowerOfThree(27));
        }
    }

    public class Solution
    {
        public bool IsPowerOfThree(int n)
        {
            if (n == 3)
                return true;

            var t = n.ToString().Sum(x => Convert.ToSByte(x) - 48);

            if (n.ToString().Sum(x => Convert.ToSByte(x) - 48) % 9 == 0)
                return true;

            return false;
        }
    }
}
