using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string di = @"C:\git\AP97982\A1S2";
            FileInfoLength(di);
        }
        public static void FileInfoLength (string FilePath)
        {
            long length = 0;
            DirectoryInfo di = new DirectoryInfo(FilePath);
            string[] subdirections = Directory.GetDirectories(FilePath);
            if (di!= null)
            {
                FileInfo[] subfiles = di.GetFiles();
                    foreach(FileInfo sub in subfiles)
                    {
                        //Console.WriteLine(sub.Length);
                        length += sub.Length;
                    }
                    Console.WriteLine(length);
                
                
            }
            if (subdirections.Length > 0)
            {
                for(int i =0; i < subdirections.Length; i++)
                {
                    FileInfoLength(subdirections[i]);
                }
                
            }
            

           


        }
    }
}
