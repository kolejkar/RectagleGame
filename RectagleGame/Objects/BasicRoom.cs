using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class BasicRoom : Objekt, ICanvas
    {
        public int width, height;
        protected Random rand;
        private bool visible;

        public BasicRoom parent;

        public bool InRoom(int Left, int Top)
        {
            if (Left > left && Left < left + width && Top > top && Top < top + height)
            {
                return true;
            }
            return false;
        }

        public bool IsVisible()
        {
            return visible;
        }

        public void SetVisible(bool visibleRoom)
        {
            visible = visibleRoom;
        }

        public void Hide()
        {
            visible = false;
        }

        public bool HasParent()
        {
            if (parent == null)
                return false;
            return true;
        }

        public BasicRoom(Random Rand)
        {
            rand = Rand;
            width = rand.Next(5, 21);
            height = rand.Next(5, 21);
            visible = true;
            parent = null;
        }

        public virtual Door Init(BasicRoom Parent)
        {
            Door door = new Door();
            door.SetKey(0);
            parent = Parent;
            return door;
        }

        public void Paint()
        {
            if (visible)
            {
                for (int i = 0; i < width; i++)
                {
                    if (UI.InScreen(top, left + i))
                    {
                        Console.SetCursorPosition(left + i, top);
                        Console.Out.Write("X");
                    }
                    if (UI.InScreen(top + height, left + i))
                    {
                        Console.SetCursorPosition(left + i, top + height);
                        Console.Out.Write("X");
                    }

                }
                for (int i = 0; i <= height; i++)
                {
                    if (UI.InScreen(top + i, left))
                    {
                        Console.SetCursorPosition(left, top + i);
                        Console.Out.Write("X");
                    }
                    if (UI.InScreen(top + i, left + width))
                    {
                        Console.SetCursorPosition(left + width, top + i);
                        Console.Out.Write("X");
                    }
                }
            }
        }
    }
}
