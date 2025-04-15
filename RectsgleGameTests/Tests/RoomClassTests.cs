using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame;

namespace RectsgleGameTests.Tests
{
    public class RoomClassTests
    {
        [Fact]
        public void ShouldCreateRoom()
        {
            //Arrage
            Random random = new Random();
            //Act
            Room room = new Room(random);
            //Assert
            Assert.True(room.IsVisible());
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void ShouldSetVisibleRoom(bool a, bool result)
        {
            //Arrage
            Random random = new Random();
            Room room = new Room(random);
            //Act
            room.SetVisible(a);
            //Assert
            Assert.Equal(result, room.IsVisible());
        }

        [Fact]
        public void ShouldHideRoom()
        {
            //Arrage
            Random random = new Random();
            Room room = new Room(random);
            //Act
            room.Hide();
            //Assert
            Assert.False(room.IsVisible());
        }

        [Theory]
        [InlineData(3, 3, true)]
        [InlineData(7, 10, false)]
        public void ShouldObjektInRoom(int a, int b, bool result)
        {
            //Arrage
            Random random = new Random();
            Room room = new Room(random);
            room.top = 1;
            room.left = 1;
            room.width = 5;
            room.height = 5;

            //Act
            var res = room.InRoom(a, b);
            //Assert
            Assert.Equal(result, res);
        }
    }
}
