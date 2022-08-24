using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1));

            Console.WriteLine(String.Join(", ", res));
        }
    }

    public class Kata
    {
        public static List<int> TreeByLevels(Node node)
        {
            if (node == null)
                return new List<int>();

            var level = new List<Node?>() { node };

            AddLevel(node, ref level);

            return level.Where(n => n != null).Select(x => x.Value).ToList();
        }

        private static void AddLevel(Node node, ref List<Node> level)
        {
            level.Add(node.Left);
            level.Add(node.Right);

            if (node.Left != null)
                AddLevel(node.Left, ref level);
            if (node.Right != null)
                AddLevel(node.Right, ref level);
        }
    }
}
