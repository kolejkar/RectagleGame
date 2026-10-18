using RectagleGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame
{
    public class Room : BasicRoom
    {
        public Monster monster = null;
        public Paper paper = null;
        public Cure cure = null;
        public Trap trap = null;

        public Room(Random Rand) : base(Rand)
        {
        }

        public override Door Init(BasicRoom Parent)
        {
            Door door = null;
            parent = Parent;
            ((Room)parent).trap = new Trap(); 
            int poz = rand.Next(0, 2);
            if (poz == 0)
            {
                door = SetRightRoom((Room)parent);
            }
            else
            if (poz == 1)
            {
                door = SetDownRoom((Room)parent);
            }
            if (parent.HasParent())
            {
                if (parent.parent.HasParent())
                {
                    int typ = rand.Next(0, 3);
                    if (typ < 1)
                    {
                        door.SetKey(rand.Next(100, 199));
                        AddMessage(door);
                    }
                    else
                    {
                        door.SetKey(0);
                    }
                }
                else
                {
                    door.SetKey(0);
                }
            }
            else
            {
                door.SetKey(0);
            }
            
            return door;
        }

        private void AddMessage(Door drzwi)
        {
            Paper msg = new Paper();
            msg.SetMessage(String.Format("Key for door: {0}", drzwi.GetKey()));
            BasicRoom room = parent;
            if (parent.HasParent())
            {
                room = parent.parent;
            }
            msg.left = room.left + rand.Next(1, room.width - 1);
            msg.top = room.top + rand.Next(1, room.height - 1);
            msg.SetTrap(room);
            ((Room)room).paper = msg;
        }

        protected Door SetDownRoom(Room Parent)
        {
            Door dzwi = new Door();
            int Top = 0;
            int Left = 0;
            Top = rand.Next(1, Parent.height - 1);
            Left = Parent.width;
            top = Top + Parent.top;
            left = Left + Parent.left;            
            dzwi.top = top + rand.Next(1, Parent.top + Parent.height - top - 1);
            dzwi.left = left;
            if (dzwi.top > (Parent.height / 2) + Parent.top)
            {
                Parent.trap.top = dzwi.top - 1;
            }
            else
            {
                Parent.trap.top = dzwi.top + 1;
            }
            Parent.trap.left = left - 1;
            return dzwi;
        }

        protected Door SetRightRoom(Room Parent)
        {
            Door dzwi = new Door();
            int Top = 0;
            int Left = 0;
            Top = Parent.height;
            Left = rand.Next(1, Parent.width - 1);
            top = Top + Parent.top;
            left = Left + Parent.left;
            dzwi.top = top;
            dzwi.left = left + rand.Next(1, Parent.left + Parent.width - left - 1);
            if (dzwi.left > (Parent.width / 2) + Parent.left)
            {
                Parent.trap.left = dzwi.left - 1;
            }
            else
            {
                Parent.trap.left = dzwi.left + 1;
            }
            Parent.trap.top = top - 1;
            return dzwi;
        }
    }
}
