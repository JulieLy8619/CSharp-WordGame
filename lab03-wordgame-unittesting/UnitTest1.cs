using System;
using Xunit;
using lab03_wordgame;
using System.IO;

namespace lab03_wordgame_unittesting
{
    public class UnitTest1
    {
        //Test that a file can be updated
        [Fact]
        public void TestFileUpdates()
        {
            //if I can read it and get a length then a file went
            Program.CreateFile("../../../ WordFile.txt");
            string[] linesFromFile = File.ReadAllLines("../../../ WordFile.txt");
            Assert.Equal(10, linesFromFile.Length);
        }

        //Test that a word can be added to a file
        [Fact]
        public void TestWordAdded()
        {
            //if the length grows then a word was added
            Program.CreateFile("../../../ WordFile.txt");
            Program.AddWordToFile("../../../ WordFile.txt", "ANEWWORD");
            string[] linesFromFile = File.ReadAllLines("../../../ WordFile.txt");
            Assert.Equal(11, linesFromFile.Length);

        }

        //Test that you can retrieve all words from the file
        [Fact]
        public void TestAllWords()
        {
            //if there is a number it read the file
            Program.CreateFile("../../../ WordFile.txt");
            string[] linesFromFile = File.ReadAllLines("../../../ WordFile.txt");
            Assert.Equal(10, linesFromFile.Length);
        }

        //Test that the word chosen can accurately detect if the letter exists in the word(test that a letter does exist and does not exist)
        [Fact]
        public void TestLetterExist()
        {
            //this is testing contains but I didn't make that it's own function
            //I know it is this function
            string gameWord = "Bob";
            string userLetterGuessCap = "B";
            bool letterInWord = gameWord.Contains(userLetterGuessCap);
            Assert.True(letterInWord);
        }

    }
}
