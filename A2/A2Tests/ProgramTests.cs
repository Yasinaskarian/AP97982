using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
       
        }

        [TestMethod()]
        public void AssignPiTest()
        {
            double pi;
            Program.AssignPi(out pi);
            Assert.AreEqual(Math.PI,pi);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int num = 4;
            Program.Square(ref num);
            Assert.AreEqual(16, num);
        }

        [TestMethod()]
        public void SwapTest()
        {
            int num1 = 1;
            int num2 = 2;
            int num12 = 1;
            int num22 = 2;
            Program.Swap(ref num1,ref num2);
            CollectionAssert.Equals($"{num22}{num12}", $"{num1}{num2}");
        }

        [TestMethod()]
        public void SumTest()
        {
            int sum;
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            Program.Sum(out sum, nums);
            CollectionAssert.Equals(15,sum);
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] nums = new int[] { 1, 2, 3 };
            int[] nums1 = new int[] { 1, 2, 3 ,4};
            int num = 4;
            Program.Append(nums, num);
            CollectionAssert.Equals(nums1, nums);
        }

        [TestMethod()]
        public void AbsArreyTest()
        {
            int[] nums = new int[] { -1, -2, -3 };
            int[] abs = new int[] { 1, 2, 3 };
            Program.AbsArrey(nums);
            CollectionAssert.Equals(abs,nums);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] num1 =new int[] {1,2,3};
            int[] num2 =new int[] {4,5,6};
            int[] num12 = new int[] { 1, 2, 3 };
            int[] num22 = new int[] { 4, 5, 6 };
            Program.ArraySwap( num1,  num2);
            CollectionAssert.Equals($"{num22}{num12}", $"{num1}{num2}");
        }

        [TestMethod()]
        public void ArraySwapTest1()
        {
            int[] num1 = new int[] { 1, 2, 3 };
            int[] num2 = new int[] { 4, 5, 6 ,7,8 };
            int[] num12 = new int[] { 1, 2, 3 };
            int[] num22 = new int[] { 4, 5, 6, 7, 8 };
            Program.ArraySwap(ref num1,ref num2);
            CollectionAssert.Equals($"{num22}{num12}", $"{num1}{num2}");
        }
    }
}