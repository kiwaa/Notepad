using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notepad.Collections
{

    class Solution
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length < 2)
                return 0;
            if (A.Length == 2)
                return A[0] + A[1];
            // idea: take 2 min values, sum them and insert back
            // unfortunately, c# doesn't have 'proper' collection 
            // so SortedDictionary will be used to handle duplicates

            // counting duplicates
            var dict = new SortedDictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                AddOrUpdate(dict, A[i]);
            }

            foreach (var pair in dict)
            {
                Console.WriteLine(pair.Key + ": " + string.Join(",", pair.Value));
            }

            var time = 0;
            while (dict.Count > 1)
            {
                // take 2 min
                var a = TakeMin(dict);
                var b = TakeMin(dict);
                Console.WriteLine(a + " " + b);
                // insert sum to structure
                AddOrUpdate(dict, a + b);
                time += a + b;
            }
            return time;
        }

        private void AddOrUpdate(SortedDictionary<int, int> dict, int value)
        {
            int count;
            if (!dict.TryGetValue(value, out count))
                count = 0;
            dict[value] = count + 1;
        }

        private int TakeMin(SortedDictionary<int, int> dict)
        {
            var minKey = dict.Keys.First();
            var value = dict[minKey];
            if (value == 1)
                dict.Remove(minKey);
            else
                dict[minKey] = value - 1;
            return minKey;
        }


    }
}
