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
