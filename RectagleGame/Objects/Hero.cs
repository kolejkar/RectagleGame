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
            Console.SetCursorPosition(0, top + 10);
            Console.Out.Write(String.Format("Helth: {0}",Helth));
            Console.SetCursorPosition(0, top + 11);
            Console.Out.Write(String.Format("Points: {0}", Points));
        }

        public void OpenItems()
        {

        }

        public int Helth = 20;

        public int Points = 0;
    }
}
