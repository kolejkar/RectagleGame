using RectagleGame;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RectsgleGameTests.Tests
{
    public class UIClassTests
    {
        [Theory]
        [InlineData(10, 5, true)]
        [InlineData(2, 20, true)]
        [InlineData(40, 5, false)]
        [InlineData(0, 121, false)]
        [InlineData(-5, 14, false)]
        [InlineData(8, -14, false)]
        public void ShouldInScreen(int top, int left, bool inScreen)
        {
            //Arrage

            //Act
            var result = UI.InScreen(top, left);
            //Assert
            Assert.Equal(inScreen, result);
        }
    }
}
