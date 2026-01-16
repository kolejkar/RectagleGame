using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame.Objects;

namespace RectsgleGameTests.Tests
{
    public class BasicRoomTests
    {
        [Fact]
        public void ShouldHasNoParent()
        {
            //Arrage
            Random random = new Random();
            //Act
            BasicRoom room = new BasicRoom(random);
            //Assert
            Assert.False(room.HasParent());
        }

        [Fact]
        public void ShouldHasParent()
        {
            //Arrage
            Random random = new Random();
            BasicRoom roomParent = new BasicRoom(random);
            //Act
            BasicRoom room = new BasicRoom(random);
            room.Init(roomParent);
            //Assert
            Assert.True(room.HasParent());
        }

        [Fact]
        public void ShouldCreateRoom()
        {
            //Arrage
            Random random = new Random();
            //Act
            BasicRoom room = new BasicRoom(random);
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
            BasicRoom room = new BasicRoom(random);
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
            BasicRoom room = new BasicRoom(random);
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
            BasicRoom room = new BasicRoom(random);
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
