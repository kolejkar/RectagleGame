using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class Cure : Objekt, ICanvas
    {

        public void Paint()
        {
            if (left > -1 && top > -1)
            {
                Console.SetCursorPosition(left, top);
                Console.Out.Write("+");
            }
        }

        private int PointsHealth;

        public void SetPoints(int points)
        {
            PointsHealth = points;
        }

        public int GetPoints()
        {
            return PointsHealth;
        }

        public void Art(Hero hero)
        {
            hero.Helth = hero.Helth + PointsHealth;
        }
    }
}
