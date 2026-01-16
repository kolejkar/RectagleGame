using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class Door : Objekt, ICanvas
    {
        private bool opened;
        private int key;

        public bool IsOpen()
        {
            return opened;
        }

        private void MessageKey()
        {
            int klucz = 0;
            Console.Clear();
            Console.SetCursorPosition(0, 25);
            Console.Write("Key: \n   Ok  ");
            Console.SetCursorPosition(6, 25);
            while (!int.TryParse(Console.ReadLine(), out klucz)) ;
            Console.SetCursorPosition(0, 26);
            Console.Write(" ->ENTER<-");
            char znak = new char();
            while (znak != 13)
            {
                znak = Console.ReadKey().KeyChar;
            }
            if (!ValidKey(klucz))
            {
                UI.ErrorMessage("Key incorrect!");
            }
            else
            {
                Open();
                UI.InfoMessage("Key correct!");
            }
        }

        public bool ValidKey(int klucz)
        {
            if (klucz == key)
            {
                return true;
            }
            return false;
        }

        public void OpenWithKey()
        {
            if (key != 0 && !IsOpen())
            {
                MessageKey();
            }
            else
            {
                Open();
            }
        }

        public void Open()
        {
                opened = !opened;
        }

        public void Paint()
        {
            if (UI.InScreen(top, left))
            {
                if (opened)
                {

                    Console.SetCursorPosition(left, top);
                    Console.Out.Write(" ");
                }
                else
                {
                    if (GetKey() > 0)
                    {
                        System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.SetCursorPosition(left, top);
                    Console.Out.Write("#");
                    System.Console.ResetColor();
                }
            }
        }

        public void SetKey(int keycode)
        {
            key = keycode;
        }

        public int GetKey()
        {
            return key;
        }
    }
}
