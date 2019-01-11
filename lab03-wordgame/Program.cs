using System;
using System.IO;

namespace lab03_wordgame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../testFile.txt";
            CreateFile(path);
            ReadFile(path);
            AppendToFile(path);
            ReadFile(path);

            Console.ReadLine(); //so prog doesn't auto quit
        }

        private static void CreateFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("Word 1");
                streamWriter.WriteLine("word 2");
                streamWriter.WriteLine("Word 3");
                streamWriter.WriteLine("tra la la");
            }
        }

        private static void ReadFile(string path)
        {
            string[] linesFromFile = File.ReadAllLines(path);
            for (int i = 0; i < linesFromFile.Length; i++)
            {
                Console.WriteLine(linesFromFile[i]);
            }
        }

        private static void AppendToFile(string path)
        {
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine("NEW WORD");
            }

        }
        //public static int Test(int num)
        //{
        //    return num;
        //}

        //test read a file

        //test write a file


    }
}
