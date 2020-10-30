using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notepad.Codility.Battleships
{
    [TestFixture]
    public class BattleshipTests
    {
        [Test]
        public void Example1()
        {
            var result_1 = new Solution().solution(4, "1B 2C,2D 4D", "2B 2D 3D 4D 4A"); // '1,1'
            Assert.AreEqual("1,1", result_1);
        }

        [Test]
        public void Example2()
        {
            var result_2 = new Solution().solution(3, "1A 1B,2C 2C", "1B"); //    # '0,1'
            Assert.AreEqual("0,1", result_2);
        }

        [Test]
        public void Example3()
        {
            var result_3 = new Solution().solution(12, "1A 2A,12A 12A", "12A"); //    # '1,0'
            Assert.AreEqual("1,0", result_3);
        }
        [Test]
        public void Custom_Empty()
        {
            var result = new Solution().solution(1, "", "1A");
            Assert.AreEqual("0,0", result);
        }

        [Test]
        public void Custom_HitNone()
        {
            var result = new Solution().solution(2, "1A 2B", "");
            Assert.AreEqual("0,0", result);
        }

        [Test]
        public void Custom_HitAll()
        {
            for (int n = 2; n <= 26; n++)
            {
                var t = Cover(n, n);
                Console.WriteLine(t);
                var res = new Solution().solution(n, "1A 2B", t); //    # '1,0'
                if (res != "1,0")
                {

                }
                Console.WriteLine(res);
            }

        }


        private static string Cover(int i, int j)
        {
            var sb = new StringBuilder();
            for (int k = 0; k < i; k++)
                for (int m = 0; m < j; m++)
                {
                    char c = (char)(m + 'A');
                    sb.Append(k + 1)
                        .Append(c)
                        .Append(' ');
                }
            return sb.ToString();
        }

    }

    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void Size()
        {
            var s1 = Solution.Ship.Parse("1A 1A"); // 1x1
            Assert.AreEqual(1, s1.Size);
            var s2 = Solution.Ship.Parse("1A 2A"); // 1x2
            Assert.AreEqual(2, s2.Size);
            var s3 = Solution.Ship.Parse("1A 3A"); // 1x3
            Assert.AreEqual(3, s3.Size);
            var s4 = Solution.Ship.Parse("1A 4A"); // 1x4
            Assert.AreEqual(4, s4.Size);
            var s5 = Solution.Ship.Parse("1A 1B"); // 2x1
            Assert.AreEqual(2, s5.Size);
            var s6 = Solution.Ship.Parse("1A 1C"); // 3x1
            Assert.AreEqual(3, s6.Size);
            var s7 = Solution.Ship.Parse("1A 1D"); // 4x1
            Assert.AreEqual(4, s7.Size);
            var s8 = Solution.Ship.Parse("1B 2C"); // 2x2
            Assert.AreEqual(4, s8.Size);

        }
    }

    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void Parse()
        {
            var s1 = Solution.Coordinate.Parse("1A");
            Assert.AreEqual(0, s1.X);
            Assert.AreEqual(0, s1.Y);
            var s2 = Solution.Coordinate.Parse("9A");
            Assert.AreEqual(0, s2.X);
            Assert.AreEqual(8, s2.Y);
            var s3 = Solution.Coordinate.Parse("10A");
            Assert.AreEqual(0, s3.X);
            Assert.AreEqual(9, s3.Y);
            var s4 = Solution.Coordinate.Parse("26Z");
            Assert.AreEqual(25, s4.X);
            Assert.AreEqual(25, s4.Y);
        }
    }
}
