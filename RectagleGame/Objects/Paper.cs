using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RectagleGame.Objects
{
    public class Paper : Objekt, ICanvas
    {
        public Trap trap;
        private string message;

        private bool trapped;

        public Paper()
        {
            trapped = false;
            trap = null;
        }

        public void SetTrap(BasicRoom room)
        {
            Trap trap1 = new Trap();
            trap = trap1;

            RandPosition(room);

            trapped = true;
        }

        private void RandPosition(BasicRoom room)
        {
            Random random = new Random();
            int position = random.Next(2);
            if (position == 0) //up
            {
                trap.left = left;
                if (room.InRoom(left, top - 1))
                {
                    trap.top = top - 1;
                }
                else
                {
                    trap.top = top + 1;
                }
            }
            else
            if (position == 1) //down
            {
                trap.left = left;
                if (room.InRoom(left, top + 1))
                {
                    trap.top = top + 1;
                }
                else
                {
                    trap.top = top - 1;
                }
            }
        }

        public bool IsTrapped()
        {
            return trapped;
        }

        public void SetMessage(string text)
        {
            message = text;
        }

        public void ReadMessage()
        {
            Console.SetCursorPosition(0, 25);
            UI.InfoMessage(message);
        }

        public void Paint()
        {
            if (UI.InScreen(top, left))
            {
                Console.SetCursorPosition(left, top);
                Console.Out.Write("M");
            }
            if (IsTrapped())
            {
                trap.Paint();
            }
        }
    }
}
