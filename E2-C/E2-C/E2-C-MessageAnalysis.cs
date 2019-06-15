using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            List<int?> repid = Messages
                 .Where(d => d.ReplyMessageId != null)
                 .Select(d=>d.ReplyMessageId)
                 .ToList();
            List<int> id = Messages
                 .Select(d => d.Id)
                 .ToList();

            MessageData max = Messages[0];
            int countmax = 0;
            int count = 0;
            for(int i = 0; i < id.Count; i++)
            {
                count = 0;
                for (int j = 0; j < repid.Count; j++)
                {
                    if (id[i] == repid[j])
                        count++;
                }
                if (count > countmax)
                {
                    countmax = count;
                    max = Messages[i];
                }

            }

            return max;
               


            
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            string[] s = Messages
                .Where(d => d.Author != "Sauleh Eetemadi")
                .Where(d => d.Author != "Ali Heydari")
                .GroupBy(g => g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(5)
                .ToArray();

            int[] i = Messages
                .Where(d => d.Author != "Sauleh Eetemadi")
                .Where(d => d.Author != "Ali Heydari")
                .GroupBy(g => g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .Take(5)
                .ToArray();
         
            Tuple<string, int>[] t = new Tuple<string, int>[s.Length];
            for (int a = 0; a < s.Length; a++)
            {
                var q = Tuple.Create(s[a], i[a]);
                t[a] = q;
            }
            return t;
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            string[] s = Messages
                 .Where(d => (d.DateTime.Hour <= 04)&&(d.DateTime.Hour>=00))
                  .GroupBy(g => g.Author)
                  .OrderByDescending(g => g.Count())
                  .Select(g => g.Key)
                  .Take(5)
                  .ToArray();

            int[] i = Messages
                .Where(d => (d.DateTime.Hour <= 04) && (d.DateTime.Hour >= 00))
                .GroupBy(g => g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .Take(5)
                .ToArray();
            
            Tuple<string, int>[] t = new Tuple<string, int>[s.Length];
            for (int a = 0; a < s.Length; a++)
            {
                var q = Tuple.Create(s[a], i[a]);
                t[a] = q;
            }
            return t;
        }

        public string StudentWithMostUnansweredQuestions()
        {
            string[] s = Messages
                .Where(d=>d.ReplyMessageId==null)
                .Where(d => d.Content.Contains("?") || d.Content.Contains("¿"))
                .GroupBy(g => g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToArray();
            
            return s[0];
        }
    }
}