using System;
using System.Collections.Generic;
using System.Text;

namespace Notepad.LeetCode.LongMultiplication
{
    // obviosly, just use BigDecimal;
    // implemented it for fun
    public class Solution
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";
            if (num1 == "1")
                return num2;
            if (num2 == "1")
                return num1;

            var maxLength = (num1.Length + 1) * (num2.Length + 1) - 1;
            var result = new char[maxLength];

            // 2 * N
            var rNum1 = num1.ToCharArray().Reverse().ToArray();
            var rNum2 = num2.ToCharArray().Reverse().ToArray();

            for (int i = 0; i < rNum2.Length; i++)
            {
                var tmp = Multiply(rNum1, rNum2[i]);
                SumWithShift(result, tmp, i);
            }
            var ans = result.Reverse().SkipWhile(x => x == '\0' || x == '0').ToArray();
            return new string(ans);
        }

        private char[] Multiply(char[] num, char digit)
        {
            var result = new char[num.Length + 1];
            // 2 * 3
            var d = ToDigit(digit);
            for (int i = 0; i < num.Length; i++)
            {
                var tmp = d * ToDigit(num[i]);
                var tmp2 = (tmp % 10) + ToDigit(result[i]);
                result[i] = ToChar(tmp2);
                result[i + 1] = ToChar(tmp / 10);
            }
            return result;
        }

        private void SumWithShift(char[] num1, char[] num2, int shift)
        {
            for (int i = 0; i < num2.Length; i++)
            {
                var s = shift + i;
                var tmp = ToDigit(num1[s]) + ToDigit(num2[i]);
                num1[s] = ToChar(tmp % 10);
                num1[s + 1] = ToChar(tmp / 10 + ToDigit(num1[s + 1]));
                //            Console.WriteLine("->" + tmp);
                //            Console.WriteLine(string.Join("", num1));
            }
        }

        private char ToChar(int num)
        {
            return (char)(num + '0');
        }

        private int ToDigit(char digit)
        {
            if (digit == '\0')
                return 0;
            return digit - '0';
        }
    }
}
