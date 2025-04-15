using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame.Objects
{
    public class Monster : Objekt, ICanvas
    {
        public void Paint()
        {
            if (left > -1 && top > -1)
            {
                Console.SetCursorPosition(left, top);
                Console.Out.Write("$");
            }
        }

        public int Helth = 2;

        //private Hero bohater;

        private bool is_attak = false;

        private bool is_moved = false;

        private IList<Room> pokoje;

        private void MissedAttack(Random rand)
        {
            if (rand.Next(0, 100) > 50)
            {
                is_attak = true;
            }
        }

        private void Attack(Hero hero)
        {
            if (HasCollision(hero) && !is_attak)
            {
                hero.Helth--;
                is_attak = true;
            }
        }

        public void Move(Random rand, Hero hero, IList<Door> dzwi)
        {
            if (is_attak==true)
            {
                is_attak = false;
            }
            int temp_left = hero.left - left;
            int temp_top = hero.top - top;
            int radianus = 10;
            if (temp_left * temp_left + temp_top * temp_top < radianus * radianus
                && temp_left * temp_left + temp_top * temp_top > 1)
            {
                double wx = hero.left - left; //oblicz wektor między zombiakiem a graczem
                double wy = hero.top - top;
                double length = Math.Sqrt(wx * wx + wy * wy); //oblicz długość wektora
                wx = wx / length; //podziel wektor przez długość
                wy = wy / length;
                int new_monster_top = top + Convert.ToInt32(wy);
                int new_monser_left= left + Convert.ToInt32(wx);
                bool move = false;
                for (int i = 0; i < pokoje.Count; i++)
                {
                    if (pokoje[i].InRoom(new_monser_left, new_monster_top))
                    {
                        move = true;
                    }
                }
                for (int i = 0; i < dzwi.Count; i++)
                {
                    if (dzwi[i].left == new_monser_left && dzwi[i].top == new_monster_top && dzwi[i].IsOpen())
                    {
                        move = true;
                    }
                }
                if (move && !is_moved)
                {
                    top = new_monster_top;  //zaokrąglij do jednośći i przemieść zombiaka
                    left = new_monser_left;
                    is_moved = true;
                }
                else
                {
                    is_moved = false;
                }
            }
            MissedAttack(rand);
            Attack(hero);                
        }

        public void SetRooms(IList<Room> rooms)
        {
            pokoje = rooms;
        }
    }
}
