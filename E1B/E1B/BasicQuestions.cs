using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class BasicQuestions
    {
        public static int OddSum(int[] nums)
        {
            int sum = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0)
                    sum += nums[i];

            }
            return sum;
        }

        public static void Swap(ref int a, ref int b)
        {
            int t= a;
            a = b;
            b = t;
        }

        public static void Swap(ref double a, ref double b)
        {
            double t = a;
            a = b;
            b = t;
        }

        public static void Swap(ref long a, ref long b)
        {
             long t = a;
            a = b;
            b = t;
        }
    }
}
