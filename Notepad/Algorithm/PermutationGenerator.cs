using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notepad.Algorithm
{
    class PermutationGenerator
    {
        public int[] State { get; }

        public PermutationGenerator(int n)
        {
            State = Enumerable.Range(0, n).ToArray();
        }

        public bool Next()
        {
            var a = State;
            var len = a.Length;
            for (int i = len - 2; i >= 0; i--)
            {
                if (a[i] < a[i + 1])
                {
                    var ind = SeekTail(i);
                    Swap(a, i, ind);
                    // sort tail if tail.len > 1
                    if (i < len - 2)
                        Array.Sort(State, i + 1, len - i - 1);
                    return true;
                }
            }
            return false;
        }

        private int SeekTail(int i)
        {
            var len = State.Length;
            for (int j = len - 1; j > i + 1; j--)
            {
                if (State[j] > State[i])
                    return j;
            }
            return i + 1;
        }

        private static void Swap(int[] a, int i, int j)
        {
            var x = a[i];
            a[i] = a[j];
            a[j] = x;
        }
    }
}
