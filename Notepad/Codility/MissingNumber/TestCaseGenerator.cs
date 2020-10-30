using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notepad.Codility.MissingNumber
{
    class TestCaseGenerator
    {
        public int[] Generate(int n, int k)
        {
            return Enumerable
                .Range(1, n + 1)
                .Where(x => x != k)
                .ToArray();
        }
    }
}
