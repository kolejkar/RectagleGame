using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class Hero : Objekt, ICanvas
    {
        public void Paint()
        {
            Console.SetCursorPosition(left, top);
            Console.Out.Write("H");
            Console.SetCursorPosition(0, 28);
            Console.Out.Write(String.Format("Health: {0}",Health));
            Console.SetCursorPosition(0, 29);
            Console.Out.Write(String.Format("Points: {0}", Points));
        }

        public void OpenItems()
        {

        }

        public int Health = 20;

        public int Points = 0;
    }
}
