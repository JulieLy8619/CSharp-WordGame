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
        }

        private static void CreateFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("Made it into the test file");
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
