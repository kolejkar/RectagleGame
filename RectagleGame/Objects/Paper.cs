using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class Paper : Objekt, ICanvas
    {
        private string message;

        public void SetMessage(string text)
        {
            message = text;
        }

        public void ReadMessage()
        {
            UI.InfoMessage(message);
        }

        public void Paint()
        {
            if (left > -1 && top > -1)
            {
                Console.SetCursorPosition(left, top);
                Console.Out.Write("M");
            }
        }
    }
}
