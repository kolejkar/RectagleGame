using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame.Objects;

namespace RectsgleGameTests.Tests
{
    public class DoorClassTests
    {
        [Theory]
        [InlineData(122, 122)]
        [InlineData(205, 205)]
        [InlineData(165, 165)]
        public void ShouldDoorHaveKey(int key, int result)
        {
            //Arrage
            Door door = new Door();
            //Act
            door.SetKey(key);
            //Assert
            Assert.Equal(result, door.GetKey());
        }

        [Fact]
        public void DoorShouldOpen()
        {
            //Arrage
            Door door = new Door();
            //Act
            door.Open();
            //Assert
            Assert.True(door.IsOpen());
        }

        [Theory]
        [InlineData(100, 100, true)]
        [InlineData(205, 304, false)]
        [InlineData(101, 101, true)]
        [InlineData(100, 905, false)]
        public void ValidateKeyToDoor(int key, int checkKey, bool validate)
        {
            //Arrage
            Door door = new Door();
            door.SetKey(key);
            //Act
            var result = door.ValidKey(checkKey);
            //Assert
            Assert.Equal(validate, result);
        }
    }
}
