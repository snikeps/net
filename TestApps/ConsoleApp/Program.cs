using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var list = new List<string>();

            list.Add("a");
            list.Add("b");
            list.Add("b");
            list.Add("b");
            list.Add("b");

            string? res = list.Where(x => x == "c").FirstOrDefault();

            //foreach (var item in res)
            //{
            //}

            if (string.IsNullOrEmpty(res))
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(res);
            }
        }
    }

    public class MyClass
    {
        public string Name { get; set; }
    }
}
