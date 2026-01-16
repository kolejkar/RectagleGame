using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame.Objects;

namespace RectsgleGameTests.Tests
{
    public class PaperTests
    {
        [Fact]
        public void ShouldHasNoTrap()
        {
            Paper paper = new Paper();
            //Arrage
           
            //Act
            
            //Assert
            Assert.False(paper.IsTrapped());
        }

        [Fact]
        public void ShouldHasTrap()
        {
            Paper paper = new Paper();
            //Arrage
            BasicRoom basicRoom = new BasicRoom(new Random());
            basicRoom.left = 1;
            basicRoom.top = 1;
            //Act
            paper.SetTrap(basicRoom);
            //Assert
            Assert.True(paper.IsTrapped());
        }

        [Fact]
        public void ShouldHasTrapObject()
        {
            Paper paper = new Paper();
            //Arrage
            BasicRoom basicRoom = new BasicRoom(new Random());
            basicRoom.left = 1;
            basicRoom.top = 1;
            //Act
            paper.SetTrap(basicRoom);
            //Assert
            Assert.NotNull(paper.trap);
        }
    }
}
