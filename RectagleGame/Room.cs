using RectagleGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame
{
    public class Room : Objekt, ICanvas
    {
        public int width, height;
        private Random rand;
        private bool visible;

        public Monster monster = null;
        public Paper paper = null;
        public Cure cure = null;

        public Room(Random Rand)
        {
            rand = Rand;
            width = rand.Next(5, 21);
            height = rand.Next(5, 21);
            visible = true;
        }

        public void Paint()
        {
            if (visible)
            {
                try
                {
                    for (int i = 0; i < width; i++)
                    {
                        Console.SetCursorPosition(left + i, top);
                        Console.Out.Write("X");
                        Console.SetCursorPosition(left + i, top + height);
                        Console.Out.Write("X");
                    }
                    for (int i = 0; i <= height; i++)
                    {
                        Console.SetCursorPosition(left, top + i);
                        Console.Out.Write("X");
                        Console.SetCursorPosition(left + width, top + i);
                        Console.Out.Write("X");
                    }
                }
                catch(Exception e)
                {

                }
            }
        }

        public Door Init(Room Parent)
        {
            Door dzwi = new Door();
            int typ=rand.Next(0, 3);
            if (typ < 1)
            {
                dzwi.SetKey(rand.Next(100, 199));
            }
            else
            {
                dzwi.SetKey(0);
            }
            int Top=0;
            int Left=0;
            int poz = rand.Next(0, 2);
            if (poz == 0)
            {
                Top = Parent.height;
                Left = rand.Next(1, Parent.width - 1);
                top = Top + Parent.top;
                left = Left + Parent.left;
                dzwi.top = top;
                dzwi.left = left + rand.Next(1, Parent.left+Parent.width-left-1);
            }
            else
            if (poz == 1)
            {
                Top = rand.Next(1, Parent.height - 1);
                Left = Parent.width;
                top = Top + Parent.top;
                left = Left + Parent.left;
                dzwi.top = top + rand.Next(1, Parent.top+Parent.height-top-1); ;
                dzwi.left = left; 
            }
            return dzwi;
        }

        public bool InRoom(int Left, int Top)
        {
            if (Left>left && Left<left+width && Top>top && Top<top+height)
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
    }
}
