using ConsoleApp;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestsLib
{
    [TestFixture]
    public class CodeWarsTests
    {
        [Test]
        public void NullTest()
        {
            Assert.AreEqual(new List<int>(), Kata.TreeByLevels(null));
        }

        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }, Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1)));
        }
    }
}
