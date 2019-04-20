using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6
{
    public struct TypeOfSize5
    {
        public byte b1;
        public byte b2;
        public byte b3;
        public byte b4;
        public byte b5;
    }
    public struct TypeOfSize22
    {
        public TypeOfSize5 T1;
        public TypeOfSize5 T2;
        public TypeOfSize5 T3;
        public TypeOfSize5 T4;
        public byte b1;
        public byte b2;

    }
    public struct TypeOfSize125
    {
        public TypeOfSize22 T1;
        public TypeOfSize22 T2;
        public TypeOfSize22 T3;
        public TypeOfSize22 T4;
        public TypeOfSize22 T5;
        public TypeOfSize5 T6;
        public TypeOfSize5 T7;
        public TypeOfSize5 T8;
    }
    public struct TypeOfSize1024
    {
        public TypeOfSize125 T1;
        public TypeOfSize125 T2;
        public TypeOfSize125 T3;
        public TypeOfSize125 T4;
        public TypeOfSize125 T5;
        public TypeOfSize125 T6;
        public TypeOfSize125 T7;
        public TypeOfSize125 T8;
        public TypeOfSize22 T9;
        public byte b1;
        public byte b2;
    }
    public struct TypeOfSize32768
    {
        public TypeOfSize1024 T1;
        public TypeOfSize1024 T2;
        public TypeOfSize1024 T3;
        public TypeOfSize1024 T4;
        public TypeOfSize1024 T5;
        public TypeOfSize1024 T6;
        public TypeOfSize1024 T7;
        public TypeOfSize1024 T8;
        public TypeOfSize1024 T9;
        public TypeOfSize1024 T10;
        public TypeOfSize1024 T11;
        public TypeOfSize1024 T12;
        public TypeOfSize1024 T13;
        public TypeOfSize1024 T14;
        public TypeOfSize1024 T15;
        public TypeOfSize1024 T16;
        public TypeOfSize1024 T17;
        public TypeOfSize1024 T18;
        public TypeOfSize1024 T19;
        public TypeOfSize1024 T20;
        public TypeOfSize1024 T21;
        public TypeOfSize1024 T22;
        public TypeOfSize1024 T23;
        public TypeOfSize1024 T24;
        public TypeOfSize1024 T25;
        public TypeOfSize1024 T26;
        public TypeOfSize1024 T27;
        public TypeOfSize1024 T28;
        public TypeOfSize1024 T29;
        public TypeOfSize1024 T30;
        public TypeOfSize1024 T31;
        public TypeOfSize1024 T32;
    }
    public struct TypeForMaxStackOfDepth10
    {
        public TypeOfSize32768 T1;
        public TypeOfSize1024 T2;
        public TypeOfSize1024 T3;
        public TypeOfSize1024 T4;
        public TypeOfSize1024 T5;
        public TypeOfSize1024 T6;
        public TypeOfSize1024 T7;
        public TypeOfSize1024 T8;
        public TypeOfSize1024 T9;
        public TypeOfSize1024 T10;
        public TypeOfSize125 T11;
        public TypeOfSize125 T12;
        public TypeOfSize125 T13;
        public TypeOfSize125 T14;
        public TypeOfSize125 T15;
        public TypeOfSize22 T16;
        public TypeOfSize22 T17;
        public byte B1;
        public byte B2;
        public byte B3;
    }
    public struct TypeForMaxStackOfDepth100
    {
    
        public TypeOfSize1024 T1;
        public TypeOfSize1024 T2;
        public TypeOfSize1024 T3;
        public TypeOfSize1024 T4;
        public TypeOfSize1024 T5;
    }
    public struct TypeForMaxStackOfDepth1000
    {
        public TypeOfSize125 T1;
        public TypeOfSize125 T2;
        public TypeOfSize125 T3;
        public TypeOfSize125 T4;

    }
    public struct TypeForMaxStackOfDepth3000
    {
        public TypeOfSize125 T1;
    }
    public struct TypeWithMemoryOnHeap
    {
        private List<int[]> mylist;


        public void Allocate()
        {
            mylist = new List<int[]>();
            for(int i=0;i<1000;i++)
            {
                int[] myArrey = new int[1000];
                mylist.Add(myArrey);
            }
        }

        public void DeAllocate()
        {
            mylist = null;
        }
    }
    public struct StructOrClass1
    {
        public int X;
    }
    public class StructOrClass2
    {
        public int X;
    }
    public class StructOrClass3
    {  
        public StructOrClass2 X;
    }
    public enum FutureHusbandType : int
    {
        None = 0,
        HasBigNose=32,
        IsBald = 16,
        IsShort = 8
    }

    public class Program
    {
        public static bool IdealHusband(FutureHusbandType fht)
        {
            if (fht == FutureHusbandType.HasBigNose|| fht == FutureHusbandType.IsBald|| fht == FutureHusbandType.IsShort) return false;
            if (fht == (FutureHusbandType.IsBald|FutureHusbandType.IsShort|FutureHusbandType.HasBigNose)) return false;
            if (fht == (FutureHusbandType.IsShort | FutureHusbandType.IsBald)) return true;
            if (fht == (FutureHusbandType.IsBald | FutureHusbandType.HasBigNose)) return true;
            if (fht == (FutureHusbandType.IsShort | FutureHusbandType.HasBigNose)) return true;


            return true;

        }


        public static int? GetObjectType(object o)
        {
            if(o is string)
            {
                return 0;
            }
            if (o is int[])
            {
                return 1;
            }
            if (o is int)
            {
                return 2;
            }
            else
            {
                return null;
            }
        }

        public static void Main(string[] args)
        {

        }
    }
}
