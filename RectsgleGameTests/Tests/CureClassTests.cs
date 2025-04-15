using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame.Objects;

namespace RectsgleGameTests.Tests
{
    public class CureClassTests
    {
        [Fact]
        public void ShouldSetPoints()
        {
            //Arrage
            Cure cure = new Cure();
            //Act
            cure.SetPoints(5);
            //Assert
            Assert.Equal(5, cure.GetPoints());
        }

        [Theory]
        [InlineData(10, 5, 15)]
        [InlineData(20, 2, 22)]
        [InlineData(1, 5, 6)]
        public void ShouldAddPointsToHero(int helthHero, int curePoints, int resultHero)
        {
            //Arrage
            Cure cure = new Cure();
            cure.SetPoints(curePoints);
            Hero hero = new Hero();
            hero.Helth = helthHero;
            //Act
            cure.Art(hero);
            //Assert
            Assert.Equal(resultHero, hero.Helth);
        }
    }
}
