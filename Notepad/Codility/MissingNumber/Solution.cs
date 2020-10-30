using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Notepad.Codility.MissingNumber
{
    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    class Solution
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var n = A.Length + 1;
            var expected = n * (n + 1) / 2;

            var sum = 0;
            for (int i = 0; i < A.Length; i++)
                sum += A[i];

            return expected - sum;

            // mono solution:
        //    class Solution
        //{
        //    public int solution(int[] A)
        //    {
        //        // write your code in C# 6.0 with .NET 4.5 (Mono)
        //        long n = A.Length + 1;
        //        long expected = n * (n + 1) / 2;

        //        var sum = 0;
        //        for (int i = 0; i < A.Length; i++)
        //            sum += A[i];

        //        return (int)(expected - sum);
        //    }
        //}
        }
    }
}
