using ConsoleApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest1()
        {
            Assert.AreEqual(true, Parentheses.ValidParentheses("()"));
        }
    }
}
