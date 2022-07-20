using ConsoleApp;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestsLib
{
    [TestFixture]
    public class CodeWarsTests
    {
        [Test]
        public void CheckPagination()
        {
            var ph = new PaginationHelper<char>(new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' }, 4);
            Assert.AreEqual(ph.PageCount, 2);
            Assert.AreEqual(ph.ItemCount, 6);
            Assert.AreEqual(ph.PageItemCount(0), 4);
            Assert.AreEqual(ph.PageItemCount(1), 2);
            Assert.AreEqual(ph.PageItemCount(2), -1);
            Assert.AreEqual(ph.PageIndex(5), 1);
            Assert.AreEqual(ph.PageIndex(2), 0);
            Assert.AreEqual(ph.PageIndex(20), -1);
            Assert.AreEqual(ph.PageIndex(-10), -1);
        }

    }
}
