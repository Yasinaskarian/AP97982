using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] posWords = Q1_GetWords(@"..\..\TwitterData\Words\positive.txt");
            string[] negWords = Q1_GetWords(@"..\..\TwitterData\Words\negative.txt");
            string[] file= Directory.GetFiles(@"..\..\TwitterData\Tweets");
            string[] AveOfLoadOfTweetOfPeople = new string[file.Length];
            string[] NameOfTweets = new string[file.Length];
            for (int i=0;i<file.Length;i++)
            {
                string[] tweets = File.ReadAllLines(file[i]);
                double AveOfLoadOfTweet = Q5_GetAvgPopChargeOfTweets(tweets, negWords, posWords);
                 AveOfLoadOfTweetOfPeople[i] = AveOfLoadOfTweet.ToString();
                NameOfTweets[i] = Path.GetFileNameWithoutExtension(file[i]);
            
            }
            string[] result = new string[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                result[i] = $"{NameOfTweets[i]}:{AveOfLoadOfTweetOfPeople[i]}";
            }

                File.WriteAllLines(@"C:\git\AP97982\A1S3\A1S3\result.txt", result);
        }

        public static int Q4_GetPopChargeOfTweet(string tweet, string negwords, string poswords)
        {
            throw new NotImplementedException();
        }

        public static string[] Q1_GetWords(string path)
        {
            string[] word = File.ReadAllLines(path); 
            return word;
        }
        public static bool Q2_IsInWords (string[] words ,string word)
        {
            for(int i=0;i<words.Length; i++)
            {
                if(words[i] == word)
                {
                    return true;
                }
            }
            return false;
        }
         public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            string[] words = tweet.Split('!', '@', '#', '?', ' ', ':', '$', '+', '-', '.', '،', '%','^','&','*',')','(','_');
            return words;
        }
        public static int Q4_GetPopChargeOfTweet(string tweet,string[] posWords,string[] negWords)
        {
            int LoadOfTweet = 0;

            string[] words = Q3_GetWordsOfTweet(tweet);
            for(int i =0; i < words.Length; i++)
            { 
                    if (Q2_IsInWords(posWords,words[i])==true)
                    {
                        LoadOfTweet++;
                    }
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (Q2_IsInWords(negWords, words[i]) == true)
                {
                    LoadOfTweet--;
                }
            }
            return LoadOfTweet;
        }
        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords,string[] posWords)
        {

            double LoadOfTweet = 0;
            foreach (string tweet in tweets)
            {
                double s= (double)Q4_GetPopChargeOfTweet(tweet, posWords, negWords);
                LoadOfTweet = s + LoadOfTweet;
            }
            double AveOfLoadOfTweet = LoadOfTweet / tweets.Length;
            return AveOfLoadOfTweet;
        }
    }
}
