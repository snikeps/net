using System;
//using System.Linq;
//using NUnit.Framework;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"MCMXC = {RomanDecode.Solution("MCMXC")}");
            Console.WriteLine($"MMVIII = {RomanDecode.Solution("MMVIII")}");
            Console.WriteLine($"MDCLXVI = {RomanDecode.Solution("MDCLXVI")}");
        }

    }
    public class RomanDecode
    {
        public static int Solution(string roman)
        {
            int res = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                if (i < roman.Length - 1)
                {
                    if (Nums(roman[i]) < Nums(roman[i + 1]))
                    {
                        res += Nums(roman[i + 1]) - Nums(roman[i]);
                        i++;
                    }
                    else
                    {
                        res += Nums(roman[i]);
                    }
                }
                else
                {
                    res += Nums(roman[i]);
                }
            }

            return res;
        }

        public static int Nums(char c) => c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new NotImplementedException()
        };
    }
}
