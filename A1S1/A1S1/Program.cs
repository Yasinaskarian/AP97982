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
            int Count = 0;

            char[] word = str.ToCharArray();
            for(int i=0; i<str.Length; i++)
            {
                if (word[i] == ' ' || word[i] < '9' || word[i] =='!' || word[i] == '.' || word[i] == '،' || word[i] == '@' || word[i] == '#')
                {
                    
                    Count ++;
                }
                else
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
            int linecount = str.Length;
            return linecount ;
        }
        public static string[] ListFiles (string dirPath) 
        {
            string[] file = Directory.GetFiles(dirPath);
            return file ;
        }
        public static double FileSize(string filePath)
        {
            int CountofWord = 0;
            string str = File.ReadAllText(filePath);
            string[] str1 = str.Split();
            for (int i = 0; i < str1.Length; i++)
            {
                CountofWord = CountofWord + str1[i].Length;
            }
            return CountofWord;
           
        }
        
    }
}
