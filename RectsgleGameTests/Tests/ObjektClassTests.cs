using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RectagleGame.Objects;

namespace RectsgleGameTests.Tests
{

    public class ObjektClassTests
    {
        [Theory]
        [InlineData(3, 3, 3, 4, true)]
        [InlineData(3, 3, 5, 4, false)]
        [InlineData(3, 10, 4, 10, true)]
        public void ShouldHasCollison(int a1, int b1, int a2, int b2, bool result)
        {
            //Arrage
            Objekt obj1 = new Hero();
            obj1.left = a1;
            obj1.top = b1;
            Objekt obj2 = new Hero();
            obj2.left = a2;
            obj2.top = b2;
            //Act
            var res = obj1.HasCollision(obj2);

            //Assert
            Assert.Equal(result, res);
        }
    }
}
