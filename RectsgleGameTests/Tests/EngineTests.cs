using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame.Objects;
using RectagleGame;

namespace RectsgleGameTests.Tests
{
    public class EngineTests
    {

        private Room InitRoom()
        {
            Random random = new Random();
            Room room = new Room(random);
            room.top = 1;
            room.left = 1;
            room.width = 5;
            room.height = 5;

            return room;
        }

        private Door InitDoor()
        {
            Door door = new Door();
            door.top = 3;
            door.left = 8;

            return door;
        }

        [Theory]
        [InlineData(1, 0, 2, 2, true)]
        [InlineData(-1, 0, 2, 2, false)]
        public void ShouldMoveInRoom(int topMove, int leftMove, int topHero, int leftHero, bool result)
        {
            Engine engine = new Engine();
            engine.pokoje = new List<Room>();
            engine.dzwi = new List<Door>();
            //Arrage
            engine.pokoje.Add(InitRoom());
            engine.dzwi.Add(InitDoor());

            Hero hero = new Hero();
            hero.top = topHero;
            hero.left = leftHero;

            engine.bohater = hero;

            //Act
            var res = engine.CheckMove(topMove, leftMove);
            //Assert
            Assert.Equal(result, res);
        }

        [Fact]
        public void ShouldMoveInRoomWithCloseDoor()
        {
            Engine engine = new Engine();
            engine.pokoje = new List<Room>();
            engine.dzwi = new List<Door>();
            //Arrage
            engine.pokoje.Add(InitRoom());
            engine.dzwi.Add(InitDoor());

            Hero hero = new Hero();
            hero.top = 3;
            hero.left = 7;

            engine.bohater = hero;

            //Act
            var res = engine.CheckMove(0, 1);
            //Assert
            Assert.False(res);
        }

        [Fact]
        public void ShouldMoveInRoomWithOpenDoor()
        {
            Engine engine = new Engine();
            engine.pokoje = new List<Room>();
            engine.dzwi = new List<Door>();
            //Arrage
            engine.pokoje.Add(InitRoom());
            Door door = InitDoor();
            door.Open();
            engine.dzwi.Add(door);

            Hero hero = new Hero();
            hero.top = 3;
            hero.left = 7;

            engine.bohater = hero;

            //Act
            var res = engine.CheckMove(0, 1);
            //Assert
            Assert.True(res);
        }
    }
}
