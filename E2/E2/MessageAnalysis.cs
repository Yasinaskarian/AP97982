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
            List<MessageData> Messages1 = Messages
                .OrderBy(d=>d.ReplyMessageId.HasValue)
                .ToList();

            MessageData m = Messages1[0];
            return m;
                
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            string[] s = Messages
                .Where(d => d.Author != "Sauleh Eetemadi")
                .Where(d => d.Author != "Ali Heydari")
                 .GroupBy(g => g.Author)
                 .OrderByDescending(g => g.Count())
                 .Select(g => g.Key)
                 .ToArray();

            int[] i = Messages
                .Where(d => d.Author != "Sauleh Eetemadi")
                .Where(d=>d.Author != "Ali Heydari")
                .GroupBy(g => g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .ToArray();
            //�?���?� �?�� Amir Esmaeili
            //�� �����131 �?�� 

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
                .Where(d => d.DateTime.Hour<4)
                .Where(d => d.DateTime.Hour > 00)
                 .GroupBy(g => g.Author)
                 .OrderByDescending(g => g.Count())
                 .Select(g => g.Key)
                 .Take(5)
                 .ToArray();

            int[] i = Messages
                .Where(d => d.DateTime.Hour < 04)
                .Where(d => d.DateTime.Hour > 00)
                .GroupBy(g => g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .Take(5)
                .ToArray();
            //�?���?� �� ���?� Amir Esmaeili ali heydari sauleh eetemadi hossein amin mir
            //�?���?� �� ���?� ����� 11�8�5�3�3
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
                .Where(d => d.Content.Contains("?") || d.Content.Contains("�"))
                .GroupBy(g=>g.Author)
                .OrderByDescending(g => g.Count())
                .Select(g=>g.Key)
                .ToArray();
            return s[0];
        }
    }
}