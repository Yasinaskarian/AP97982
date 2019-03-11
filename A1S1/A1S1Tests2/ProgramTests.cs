using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }
        private static string[] GetTestDir(out string tmpDir)

        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
                File.Delete(tmpDir);

            if (!Directory.Exists(tmpDir))
                Directory.CreateDirectory(tmpDir);
            else
                foreach (string file in Directory.GetFiles(tmpDir))
                    File.Delete(file);

            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();
            for (int i = 0; i < rndNum; i++)
            {
                string fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }
            return files.ToArray();
        }
[TestMethod()]
        public void MainTest()
        {
           
        }

        [TestMethod()]
        public void CaculateLengthTest()
        {
            string str = "abc def 123";
            Assert.AreEqual(11,Program.CaculateLength(str));
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            string str = "ab12c d@ef 1.23";
            Assert.AreEqual(6, Program.LetterCount(str));
        }

        [TestMethod()]
        public void LineCountTest()
        {
            string str = "hi\nbye\ngood\ns";
            Assert.AreEqual(4, Program.LineCount(str));
        }

        [TestMethod()]
        public void FileLineCountTest()
        {
            int linecount;
            int charCount;
            string S=GetTestFile(out linecount, out charCount);

            Assert.AreEqual(linecount,Program.FileLineCount(S));
        }

        [TestMethod()]
        public void ListFilesTest()
        {
            string Dir;
            string[] E = GetTestDir(out Dir);
            CollectionAssert.Equals(E, Program.ListFiles(Dir));
        }

        [TestMethod()]
        public void FileSizeTest()
        {
            string Dir;
            int charCount;
            int lineCount;
            Dir =GetTestFile(out lineCount, out charCount);
            CollectionAssert.Equals(charCount, Program.FileSize(Dir));
        }
    }
}