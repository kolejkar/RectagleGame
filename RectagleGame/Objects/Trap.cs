using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class Trap : Objekt, ICanvas
    {
        private bool activeted;

        public Trap()
        {
            activeted = true;
        }

        public void Paint()
        {
            System.Console.SetCursorPosition(left, top);
            if (activeted == true)
            {
                System.Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            System.Console.Write("T");
            System.Console.ResetColor();
        }

        public bool IsUsed()
        {
            return !activeted;
        }

        public void HitHero(Hero hero)
        {
            if (left == hero.left && top == hero.top && activeted)
            {
                hero.Helth--;
                activeted = false;
            }
        }
    }
}
