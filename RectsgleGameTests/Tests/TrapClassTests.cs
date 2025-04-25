using RectagleGame.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RectsgleGameTests.Tests
{
    public class TrapClassTests
    {
        [Fact]
        public void ShouldCreateAndActivateTrap()
        {
            //Arrage            
            //Act
            Trap trap = new Trap();
            //Assert
            Assert.False(trap.IsUsed());
        }

        [Fact]
        public void ShouldHeroUsedTrap()
        {
            //Arrage
            Hero hero = new Hero();
            hero.top = 5;
            hero.left = 5;
            Trap trap = new Trap();
            trap.top = 5;
            trap.left = 5;
            //Act
            trap.HitHero(hero);
            //Assert
            Assert.True(trap.IsUsed());
        }

        [Fact]
        public void ShouldHeroNotUsedTrap()
        {
            //Arrage
            Hero hero = new Hero();
            hero.top = 6;
            hero.left = 6;
            Trap trap = new Trap();
            trap.top = 5;
            trap.left = 5;
            //Act
            trap.HitHero(hero);
            //Assert
            Assert.False(trap.IsUsed());
        }

        [Fact]
        public void ShouldTrapDamagedHeroOnUsedTrap()
        {
            //Arrage
            Hero hero = new Hero();
            hero.Helth = 10;
            hero.top = 5;
            hero.left = 5;
            Trap trap = new Trap();
            trap.top = 5;
            trap.left = 5;
            //Act
            trap.HitHero(hero);
            //Assert
            Assert.Equal(9, hero.Helth);
        }
    }
}
