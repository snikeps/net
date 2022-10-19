using System;
using System.Linq;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((decimal)3.0);
            Console.WriteLine(new Solution().IsPowerOfThree(27));
            Console.WriteLine(new Solution().IsPowerOfThree(243));
            Console.WriteLine(new Solution().IsPowerOfThree(14348907));
            Console.WriteLine(new Solution().IsPowerOfThree(45));
            Console.WriteLine(new Solution().IsPowerOfThree(0));
            Console.WriteLine(new Solution().IsPowerOfThree(-1));
            Console.WriteLine(new Solution().IsPowerOfThree(244));
            Console.WriteLine(new Solution().IsPowerOfThree(4782968)); // expected false
        }
    }

    public class Solution
    {
        public bool IsPowerOfThree(int n)
        {
            if (n < 3)
                return false;
            var res = (decimal)Math.Log(n, 3);
            return (double)res == Math.Truncate((double)res) ? true : false;
        }
    }
}
