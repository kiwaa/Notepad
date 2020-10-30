using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notepad.Codility.MissingNumber
{
    [TestFixture]
    public class Tests
    {
        [TestCase(100_000, 1)]
        public void MissingNumber(int N, int expected)
        {
            var gen = new Codility.MissingNumber.TestCaseGenerator();
            var test = gen.Generate(N, expected);

            var s = new Codility.MissingNumber.Solution();
            var actual = s.solution(test);

            Assert.AreEqual(expected, actual);
//            Console.WriteLine("Test: ({0})", string.Join(",", test));
        }
    }
}
