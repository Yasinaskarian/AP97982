using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }
        public static void AssignPi(out double pi)
         => pi = Math.PI;
        public static void Square(ref int num)
          => num = num * num;
        public static void Swap(ref int num1, ref int num2)
        {
            int test = num1;
            num1 = num2;
            num2 = test;

        }
        public static void Sum(out int sum, params int[] nums)
        {
            sum = 0;
            for (int i = 0; i < nums.Length; i++)
             sum += nums[i];  
        }
        public static void Append(int[] nums,int num)
        {
            //int[] NewNums = new int[nums.Length + 1] ;
            //for (int i = 0; i <= nums.Length; i++)
            //{
            //    if (i == nums.Length)
            //    {
            //        NewNums[i] = num;
            //    }
            //    else
            //    {
            //        NewNums[i] = nums[i];
            //    }
            //}
            //nums = NewNums;
            List<int> newNums = new List<int>();
            for(int i = 0; i < nums.Length; i++)
             newNums.Add(nums[i]);
            newNums.Add(num);
            nums = newNums.ToArray();
        }
        public static void AbsArrey(int[] nums)
        {
           
            for (int i = 0; i < nums.Length; i++)
                nums[i] = Math.Abs(nums[i]);
        }
        public static void ArraySwap(int[] nums1, int[] nums2)
        {
            int test = 0;
            for(int i =0;i<nums1.Length;i++)
            {
                test = nums2[i];
                nums2[i] = nums1[i];
                nums1[i] = test;
            }
        }
        public static void ArraySwap(ref int[] nums1,ref int[] nums2)
        {
            List<int> num11 = new List<int>();
            for(int i=0;i<nums1.Length;i++)
                num11.Add(nums1[i]);
            List<int> num22 = new List<int>();
            for (int i = 0; i < nums2.Length; i++)
                num22.Add(nums2[i]);
            List<int> test = new List<int>();
            test = num11;
            num11 = num22;
            num22 = test;
            nums2 = num22.ToArray();
            nums1 = num11.ToArray();
            //int test = 0;
            //if (nums1.Length > nums2.Length)
            //{
            //    int length = nums2.Length;
            //    Array.Resize(ref nums2, nums1.Length);

            //    for (int i = 0; i < nums1.Length; i++)
            //    {

            //        test = nums2[i];
            //        nums2[i] = nums1[i];
            //        nums1[i] = test;
            //    }
            //    Array.Resize(ref nums1, length);
            //}
            //else
            //{
            //    ArraySwap(ref nums2, ref nums1);
            //}

        }
    }
}
