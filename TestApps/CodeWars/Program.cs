using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var helper = new PaginationHelper<char>(new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' }, 4);
            Console.WriteLine($"PageCount = {helper.PageCount}");
            Console.WriteLine($"ItemCount = {helper.ItemCount}");
            Console.WriteLine($"PageItemCount(0) = {helper.PageItemCount(0)}");
            Console.WriteLine($"PageItemCount(1) = {helper.PageItemCount(1)}");
            Console.WriteLine($"PageItemCount(2) = {helper.PageItemCount(2)}");
            Console.WriteLine($"PageIndex(5) = {helper.PageIndex(5)}");
            Console.WriteLine($"PageIndex(2) = {helper.PageIndex(2)}");
            Console.WriteLine($"PageIndex(20) = {helper.PageIndex(20)}");
            Console.WriteLine($"PageIndex(-10) = {helper.PageIndex(-10)}");
        }
    }
}
