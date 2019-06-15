using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool Equals(object obj)
        {
            if(obj is FullName)
            {
                FullName f = obj as FullName;
                return ((f.FirstName == this.FirstName) && (f.LastName == this.LastName));
            }
            return false;
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            string[] num = expression.Split('+');
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                char[] c = num[i].ToCharArray();
                if (num[i] == "")
                    throw new InvalidDataException();
                if ((c[0] >= 'a' && c[0] <= 'z') || (c[0] >= 'A' && c[0] <= 'Z'))
                    throw new FormatException();

            }

            for (int i = 0; i < num.Length; i++)
            {
                sum += int.Parse(num[i]);
            }
            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            string[] num = expression.Split('+');
            value = 0;
            for (int i = 0; i < num.Length; i++)
            {
                char[] c = num[i].ToCharArray();
                if (num[i] == "")
                    return false;
                if ((c[0] >= 'a' && c[0] <= 'z') || (c[0] >= 'A' && c[0] <= 'Z'))
                    return false;

            }

            for (int i = 0; i < num.Length; i++)
            {
                value += int.Parse(num[i]);
            }
            return true;

        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            double a = 1;
            double b = 3;
            double pi = 1;
            long i = 1;
            while (true)
            {
                if (i % 2 == 0)
                {
                    pi += a / b;
                }
                else
                    pi -= a / b;
                b = b + 2;
                i++;
                if(Math.Abs(Math.Round(Math.PI, 7) -4*pi)< 0.00000005)
                    return (int)i;
            }
          
           
        }

        public static int Fibonacci(this int n)
        {
            int a = 1;
            int b = 2;
            int c = 0;
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }
    }
}