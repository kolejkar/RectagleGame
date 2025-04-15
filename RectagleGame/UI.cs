using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame
{
    public class UI
    {
        public static void ErrorMessage(string msg)
        {
            Console.Write("ERROR: "+msg);
            Console.Write(" ->ENTER<-");
            char znak = new char();
            while (znak != 13)
            {
                znak = Console.ReadKey().KeyChar;
            }
        }

        public static void InfoMessage(string msg)
        {
            Console.Write("INFO: " + msg);
            Console.Write(" ->ENTER<-");
            char znak = new char();
            while (znak != 13)
            {
                znak = Console.ReadKey().KeyChar;
            }
        }
    }
}
