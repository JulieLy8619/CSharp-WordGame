using System;
using Xunit;
using lab03_wordgame;

namespace lab03_wordgame_unittesting
{
    public class UnitTest1
    {
        [Fact]
        public void TestRandomWorks()
        {
            Assert.Equal(1, Program.RandomNum(100)); //how can I predict the random #
        }
        [Fact]
        public void TestRandomNotWorks()
        {
            Assert.NotEqual(1, Program.RandomNum(10)); //how can I predict the random #
        }


    }
}

/*
Tests
Test that your app has the following functionality:

Test that a file can be updated
Test that a word can be added to a file
Test that you can retrieve all words from the file
Test that the word chosen can accurately detect if the letter exists in the word(test that a letter does exist and does not exist)
*/