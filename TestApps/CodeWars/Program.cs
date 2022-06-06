using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Rgb(255, 255, 255) = {Kata.Rgb(255, 255, 255)}");
            Console.WriteLine($"Rgb(255, 255, 300) = {Kata.Rgb(255, 255, 300)}");
            Console.WriteLine($"Rgb(0,0,0) = {Kata.Rgb(0, 0, 0)}");
            Console.WriteLine($"Rgb(148, 0, 211) = {Kata.Rgb(148, 1, 211)}");
        }

    }
    public class Kata
    {
        public static string Rgb(int r, int g, int b)
        {
            r = Math.Max(Math.Min(r, 255), 0);
            g = Math.Max(Math.Min(g, 255), 0);
            b = Math.Max(Math.Min(b, 255), 0);

            return string.Concat(r.ToString("X2"), g.ToString("X2"), b.ToString("X2"));
        }
    }
}
