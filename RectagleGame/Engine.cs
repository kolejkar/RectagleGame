using RectagleGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectagleGame
{
    public class Engine
    {
        private char znak;
        public Hero bohater;
        public IList<Room> pokoje;
        public IList<Door> dzwi;
        private Random rand;

        public Engine()
        {
            znak = new char();
            bohater = new Hero();
            rand = new Random();
            pokoje = new List<Room>();
            dzwi = new List<Door>();
        }

        private void Rysuj()
        {
            Console.Clear();
            for (int i = 0; i < pokoje.Count; i++)
            {
                pokoje[i].Hide();
            }
            for (int i = 0; i < pokoje.Count; i++)
            {
                if (pokoje[i].InRoom(bohater.left, bohater.top))
                {
                    pokoje[i].SetVisible(true);
                    if (i < pokoje.Count - 1 && dzwi[i].IsOpen())
                    {
                        pokoje[i + 1].SetVisible(true);
                    }
                    if (i > 0 && dzwi[i - 1].IsOpen())
                    {
                        pokoje[i - 1].SetVisible(true);
                        pokoje[i - 1].Paint();
                    }
                }
                if (i < pokoje.Count - 1 && dzwi[i].left == bohater.left && dzwi[i].top == bohater.top && dzwi[i].IsOpen())
                {
                    pokoje[i + 1].SetVisible(true);
                    pokoje[i].SetVisible(true);
                }
                pokoje[i].Paint();
            }
            for (int i = 0; i < pokoje.Count; i++)
            {
                for (int j = 0; j < dzwi.Count; j++)
                {
                    if (dzwi[j].left >= pokoje[i].left && dzwi[j].left <= pokoje[i].left + pokoje[i].width
                        && dzwi[j].top >= pokoje[i].top && dzwi[j].top <= pokoje[i].top + pokoje[i].height)
                    {
                        if (pokoje[i].IsVisible())
                            dzwi[j].Paint();
                    }
                }
                foreach (Room room in pokoje.Where(p => p.paper != null))
                {
                    if (pokoje[i].InRoom(room.paper.left, room.paper.top) && pokoje[i].IsVisible())
                    {
                        room.paper.Paint();
                    }
                }
                foreach (Room room in pokoje.Where(p => p.cure != null))
                {
                    if (pokoje[i].InRoom(room.cure.left, room.cure.top) && pokoje[i].IsVisible())
                        room.cure.Paint();
                }
                foreach (Room room in pokoje.Where(p => p.trap != null))
                {
                    if (pokoje[i].InRoom(room.trap.left, room.trap.top) && pokoje[i].IsVisible())
                        room.trap.Paint();
                }
                foreach (Room room in pokoje.Where(p => p.monster != null))
                {
                    if (pokoje[i].IsVisible())
                    {
                        if (room.monster.left >= pokoje[i].left && room.monster.left <= pokoje[i].left + pokoje[i].width
                        && room.monster.top >= pokoje[i].top && room.monster.top <= pokoje[i].top + pokoje[i].height)
                        {
                            room.monster.Paint();
                        }
                    }
                }
            }
            bohater.Paint();
        }

        private Cure AddCure()
        {
            Cure cure = new Cure();
            cure.left = pokoje[pokoje.Count - 1].left + rand.Next(1, pokoje[pokoje.Count - 1].width - 1);
            cure.top = pokoje[pokoje.Count - 1].top + rand.Next(1, pokoje[pokoje.Count - 1].height - 1);
            cure.SetPoints(rand.Next(3, 5));
            return cure;
        }

        private Monster AddMonster()
        {
            Monster monster = new Monster();
            monster.left = pokoje[pokoje.Count - 1].left + rand.Next(1, pokoje[pokoje.Count - 1].width - 1);
            monster.top = pokoje[pokoje.Count - 1].top + rand.Next(1, pokoje[pokoje.Count - 1].height - 1);
            monster.SetRooms(pokoje);
            return monster;
        }

        private void GenerujPokuj()
        {
            if (pokoje[pokoje.Count-1].InRoom(bohater.left, bohater.top))
            {
                Room pokoj = new Room(rand);
                dzwi.Add(pokoj.Init(pokoje[pokoje.Count-1]));
                if (rand.Next(0, 100) > 0.5)
                {                 
                    pokoj.monster = AddMonster();
                }
                if (pokoj.width > 10 || pokoj.height > 10)
                {                   
                    pokoj.cure = AddCure();
                }
                pokoje.Add(pokoj);
                //rooms++;
            }
        }

        private void InitGame()
        {
            Room pokoj = new Room(rand);
            pokoj.top = 5;
            pokoj.left = 5;
            pokoje.Add(pokoj);
            bohater.top = pokoje[0].top + pokoje[0].height - 1;
            bohater.left = pokoje[0].left + pokoje[0].width - 1;
        }

        public void Run()
        {
            InitGame();
            while (znak != 27 && bohater.Health > 0)
            {
                GenerujPokuj();
                Rysuj();
                znak = Console.ReadKey().KeyChar;
                if (znak == 'w')
                {
                    if (CheckMove(-1, 0))
                    {
                        MoveUp();
                    }
                }
                if (znak == 's')
                {
                    if (CheckMove(1, 0))
                    {
                        MoveDown();
                    }
                }
                if (znak == 'a')
                {
                    if (CheckMove(0, -1))
                    {
                        MoveLeft();
                    }
                }
                if (znak == 'd')
                {
                    if (CheckMove(0, 1))
                    {
                        MoveRight();
                    }
                }
                if (znak == ' ')
                {
                    Attack();
                    OpenDoor();
                    ReadMessage();
                    DrinkCure();
                }
                else
                {
                    foreach (Room room in pokoje.Where(p => p.monster != null))
                    {
                        room.monster.Move(rand, bohater, dzwi);
                    }
                }
                UseTrap();
            }
            if (bohater.Health <= 0)
                GameOver();
        }

        public bool CheckMove(int top, int left)
        {
            for (int i = 0; i < pokoje.Count; i++)
            {
                if (pokoje[i].InRoom(bohater.left + left, bohater.top + top))
                {
                    return true;
                }
            }
            for (int i = 0; i < dzwi.Count; i++)
            {
                if (dzwi[i].left == bohater.left + left && dzwi[i].top == bohater.top + top && dzwi[i].IsOpen())
                {
                    return true;
                }
            }
            return false;
        }

        private void MoveRight()
        {
            foreach (Room pok in pokoje)
            {
                pok.left--;
                if (pok.monster != null)
                {
                    pok.monster.left--;
                }
                if (pok.paper != null)
                {
                    pok.paper.left--;
                    if (pok.paper.IsTrapped())
                    {
                        pok.paper.trap.left--;
                    }
                }
                if (pok.cure != null)
                {
                    pok.cure.left--;
                }
                if (pok.trap != null)
                {
                    pok.trap.left--;
                }
            }
            foreach (Door door in dzwi)
            {
                door.left--;
            }
        }

        private void MoveLeft()
        {
            foreach (Room pok in pokoje)
            {
                pok.left++;
                if (pok.monster != null)
                {
                    pok.monster.left++;
                }
                if (pok.paper != null)
                {
                    pok.paper.left++;
                    if (pok.paper.IsTrapped())
                    {
                        pok.paper.trap.left++;
                    }
                }
                if (pok.cure != null)
                {
                    pok.cure.left++;
                }
                if (pok.trap != null)
                {
                    pok.trap.left++;
                }
            }
            foreach (Door door in dzwi)
            {
                door.left++;
            }
        }

        private void MoveDown()
        {
            foreach (Room pok in pokoje)
            {
                pok.top--;
                if (pok.monster != null)
                {
                    pok.monster.top--;
                }
                if (pok.paper != null)
                {
                    pok.paper.top--;
                    if (pok.paper.IsTrapped())
                    {
                        pok.paper.trap.top--;
                    }
                }
                if (pok.cure != null)
                {
                    pok.cure.top--;
                }
                if (pok.trap != null)
                {
                    pok.trap.top--;
                }
            }
            foreach (Door door in dzwi)
            {
                door.top--;
            }
        }

        private void MoveUp()
        {
            foreach (Room pok in pokoje)
            {
                pok.top++;
                if (pok.monster != null)
                {
                    pok.monster.top++;
                }
                if (pok.paper != null)
                {
                    pok.paper.top++;
                    if (pok.paper.IsTrapped())
                    {
                        pok.paper.trap.top++;
                    }
                }
                if (pok.cure != null)
                {
                    pok.cure.top++;
                }
                if (pok.trap != null)
                {
                    pok.trap.top++;
                }
            }
            foreach (Door door in dzwi)
            {
                door.top++;
            }
        }

        private void UseTrap()
        {
            foreach (Room room in pokoje.Where(p => p.trap != null))
            {
                room.trap.HitHero(bohater);
            }
            foreach (Room room in pokoje.Where(p => p.paper != null))
            {
                if (room.paper.IsTrapped())
                {
                    room.paper.trap.HitHero(bohater);
                }
            }
        }

        private void DrinkCure()
        {
            foreach (Room room in pokoje.Where(p => p.cure != null))
            {
                if (bohater.HasCollision(room.cure))
                {
                    room.cure.Art(bohater);
                    room.cure = null;
                }
            }
        }

        private void ReadMessage()
        {
            foreach (Room room in pokoje.Where(p => p.paper != null))
            {
                if (bohater.HasCollision(room.paper))
                {
                    room.paper.ReadMessage();
                    room.paper = null;
                }
            }
        }

        private void OpenDoor()
        {
            for (int i = 0; i < dzwi.Count; i++)
            {
                foreach (Room room in pokoje.Where(p => p.monster != null))
                {
                    if (room.monster.top == dzwi[i].top && room.monster.left == dzwi[i].left)
                        return;
            }
                if (bohater.HasCollision(dzwi[i]))
                {
                    dzwi[i].OpenWithKey();
                }
            }
        }

        private void Attack()
        {
            foreach (Room room in pokoje.Where(p => p.monster != null))
            {
                if (bohater.HasCollision(room.monster))
                {
                    room.monster.Health--;
                }
                if (room.monster.Health <= 0)
                {
                    room.monster = null;
                    bohater.Points++;
                    break;
                }
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("You are dead!");
            Console.WriteLine("The Game is finish.");
            Console.WriteLine("->ENTER<-");
            char znak = new char();
            while (znak != 13)
            {
                znak = Console.ReadKey().KeyChar;
            }
        }
    }
}
