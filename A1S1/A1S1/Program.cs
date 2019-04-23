using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S1
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
        public static int CaculateLength(string str)
        {
            int CountofLength = str.Length;
           return CountofLength;
        }
        public static int LetterCount(string str)
        {
            
            int CountofWord = 0;
            char[] word = str.ToCharArray();
            for(int i=0; i<str.Length; i++)
            {
                if (char.IsLetter(word[i]))
                {
                    CountofWord++;
                }
            }
            return CountofWord;
        }
        public static int LineCount(string str)
        {
            string[] str2 = str.Split('\n');
            int linecount = str2.Length;
            

            return linecount  ;
        }
        public static int FileLineCount (string filePath)
        {
            string[] str = File.ReadAllLines(filePath);
            return str.Length;
        }
        public static string[] ListFiles (string dirPath) 
        {
            string[] file = Directory.GetFiles(dirPath);
            return file ;
        }
        public static double FileSize(string filePath)
        {
            string str = File.ReadAllText(filePath);
            return str.Length;
        }
        
    }
}
