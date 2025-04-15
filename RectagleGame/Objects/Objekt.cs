using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    abstract public class Objekt
    {
        public int left, top;

        public bool HasCollision(Objekt obj)
        {
            if (this.left + 1 == obj.left && this.top == obj.top)
            {
                return true;
            }
            else
            if (this.left - 1 == obj.left && this.top == obj.top)
            {
                return true;
            }
            else
            if (this.left == obj.left && this.top + 1 == obj.top)
            {
                return true;
            }
            else
            if (this.left == obj.left && this.top - 1 == obj.top)
            {
                return true;
            }
            return false;
        }
    }
}
