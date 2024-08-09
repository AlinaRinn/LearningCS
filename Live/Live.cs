using System;
using System.Collections.Generic;

namespace Live
{
    class Program
    {
        class Rabbit
        {
            public int starve = 5,
                       saturation = 5,
                       hp = 10,
                       movement = 2,
                       satisfaction = 0;

            public int x = 0, y = 0;
        }

        class Wolf
        {
            public int starve = 7,
                       hp = 15,
                       movement = 1,
                       satisfaction = 0;

            public int x = 0, y = 0;
        }

        class Spawner
        {
            public int x = 0, y = 0;
        }

        static int Input()                                                   // Entering Area size
        {
            Console.WriteLine("Enter Area size:");
            int size;
            while (true)
            {
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                    if (size < 100)
                        break;
                    else
                        Console.WriteLine("\nEnter int, <100");
                }
                catch
                {
                    Console.WriteLine("\nEnter int, <100");
                }
            }
            return size;
        }

        static char[,] EarthAndGrass(int size, char[,] area)                                          // Fulling Earth  
        {         
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    area[i, j] = 'E';
                }
            }
            Random ran = new Random();
            int grass_count = (size * size) / 10;
            for (int i = 0; i < grass_count; i++)
            {
                int grass_x = ran.Next(0, size); int grass_y = ran.Next(0, size);
                area[grass_x, grass_y] = 'G';
                //Console.WriteLine("Random " + i + ":" + grass_x + "  " + grass_y);
            }
            return area;
        }

        static char[,] WolvesAndRabbits(int size, char[,] area, List<Wolf> wo, List<Rabbit> ra)
        {
            Random ran = new Random();
            int wolf_count = (size * size) / 16;
            int rabbit_count = (size * size) / 16;
            for (int i = 0; i < wolf_count; i++)
            {
                int wolf_x = ran.Next(0, size); int wolf_y = ran.Next(0, size);
                if (area[wolf_x, wolf_y] == 'E')
                {                   
                    area[wolf_x, wolf_y] = 'W';
                    wo.Add(new Wolf() { x = wolf_x, y = wolf_y});
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < rabbit_count; i++)
            {
                int rabbit_x = ran.Next(0, size); int rabbit_y = ran.Next(0, size);
                if (area[rabbit_x, rabbit_y] == 'E') 
                {                   
                    area[rabbit_x, rabbit_y] = 'R';
                    ra.Add(new Rabbit() { x = rabbit_x, y = rabbit_y });
                }
                else
                {
                    i--;
                }
            }
            return area;
        }

        static char[,] RandomSpawn(int size, char[,] area, List<Wolf> wo, List<Rabbit> ra)
        {
            char character = '1'; int amount = 0;
            try
            {
                Console.Write("Enter character (W/R): "); character = Console.ReadKey().KeyChar;
                Console.Write("\nEnter amount: "); amount = Convert.ToInt32(Console.ReadLine()); Console.Write("\n");
            }
            catch
            {
                Console.WriteLine("Invalid data");
            }
            if (amount > (size * size - (wo.Count + ra.Count)))
            {
                Console.WriteLine("Not enought space on map. Enter a smoller amount of characters");
                amount = 0;
            }
            Random ran = new Random();
            for (int i = 0; i < amount; i++)
            {
                if ((character != 'W') && (character != 'w') && (character != 'R') && (character != 'r'))
                {
                    Console.WriteLine("Invalid character. Please, enter W or R");
                    break;
                }
                int char_x = ran.Next(0, size); int char_y = ran.Next(0, size);
                if (((area[char_x, char_y] == 'E')||(area[char_x, char_y] == 'G')) && ((character == 'W') || (character == 'w')))
                {
                    area[char_x, char_y] = 'W';
                    wo.Add(new Wolf() { x = char_x, y = char_y });
                }
                else if (((area[char_x, char_y] == 'E') || (area[char_x, char_y] == 'G')) && ((character == 'R') || (character == 'r')))
                {
                    area[char_x, char_y] = 'R';
                    ra.Add(new Rabbit() { x = char_x, y = char_y });
                }
                else
                {
                    i--;
                }
            }

            return area;
        }

        static void Live(char[,] area, List<Wolf> wo, List<Rabbit> ra)
        {
            for (int i = 0; i < ra.Count; i++)
            {
                ra[i].hp--; ra[i].starve--; ra[i].satisfaction++;
                if (ra[i].hp <= 0 || ra[i].starve < 0)
                {
                    area[ra[i].x, ra[i].y] = 'E';
                    ra.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < wo.Count; i++)
            {
                wo[i].hp--; wo[i].starve--; wo[i].satisfaction++;
                if (wo[i].hp <= 0 || wo[i].starve < 0)
                {
                    area[wo[i].x, wo[i].y] = 'E';
                    wo.RemoveAt(i);
                    i--;
                }
            }
        }

        static void MoveWO(int size, char[,] area, List<Wolf> wo, List<Rabbit> ra)
        {
            foreach (var a in wo)
            {
                area[a.x, a.y] = 'E';
                int backX = a.x, backY = a.y;
                Random ran = new Random();
                int direction = ran.Next(0, 4);
                if (direction == 0)
                {
                    a.x += a.movement;
                }
                else if (direction == 1)
                {
                    a.x -= a.movement;
                }
                else if (direction == 2)
                {
                    a.y += a.movement;
                }
                else if (direction == 3)
                {
                    a.y -= a.movement;
                }
                // Debug
                if (a.y < 0)
                {
                    a.y = 0;
                }
                if (a.y > size - 1)
                {
                    a.y = size - 1;
                }
                if (a.x < 0)
                {
                    a.x = 0;
                }
                if (a.x > size - 1)
                {
                    a.x = size - 1;
                }

                // Placing
                if (area[a.x, a.y] == 'E')
                {
                    area[a.x, a.y] = 'W';
                }
                else if (area[a.x, a.y] == 'G')
                {
                    area[a.x, a.y] = 'W';
                }
                else if (area[a.x, a.y] == 'W')
                {
                    a.x = backX;
                    a.y = backY;
                    area[backX, backY] = 'W';
                }
                else if (area[a.x, a.y] == 'R')
                {
                    var del = 0;
                    area[a.x, a.y] = 'W';
                    a.starve = 7;
                    foreach (var b in ra)
                    {
                        if (b.x == a.x && b.y == a.y)
                        {
                            del = ra.IndexOf(b);
                        }
                    }
                    ra.RemoveAt(del);
                }
            }
        }

        static void MoveRA(int size, char[,] area, List<Rabbit> ra)
        {
            foreach (var a in ra)
            {
                area[a.x, a.y] = 'E';
                int backX = a.x, backY = a.y;
                Random ran = new Random();
                int direction = ran.Next(0, 4);
                int movement = a.movement - ran.Next(0, 1);
                if (direction == 0)
                {
                    a.x += movement;
                }
                else if (direction == 1)
                {
                    a.x -= movement;
                }
                else if (direction == 2)
                {
                    a.y += movement;
                }
                else if (direction == 3)
                {
                    a.y -= movement;
                }
                // Debug
                if (a.y < 0)
                {
                    a.y = 0;
                }
                if (a.y > size - 1)
                {
                    a.y = size - 1;
                }
                if (a.x < 0)
                {
                    a.x = 0;
                }
                if (a.x > size - 1)
                {
                    a.x = size - 1;
                }

                // Placing
                if (area[a.x, a.y] == 'E')
                {
                    area[a.x, a.y] = 'R';
                }
                else if (area[a.x, a.y] == 'G')
                {
                    area[a.x, a.y] = 'R';
                    a.starve += a.saturation;
                }
                else if (area[a.x, a.y] == 'W')
                {
                    a.x = backX;
                    a.y = backY;
                    area[backX, backY] = 'R';
                }
                else if (area[a.x, a.y] == 'R')
                {
                    a.x = backX;
                    a.y = backY;
                    area[backX, backY] = 'R';
                }
            }
        }

        static int Fuck(int size, char[,] area, List<Wolf> wo, List<Rabbit> ra, List<Spawner> spwn)
        {
            foreach (var a in ra)
            {
                if (a.x != 0 && a.y != 0 && a.x != size - 1 && a.y != size - 1 && a.satisfaction >= 2)
                {
                    if (area[a.x + 1, a.y] == 'R')
                    {
                        if (area[a.x - 1, a.y] == 'E' || area[a.x - 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x - 1, y = a.y });
                            area[a.x - 1, a.y] = 'R';
                            a.satisfaction = 0;
                        }
                    }
                    else if (area[a.x - 1, a.y] == 'R')
                    {
                        if (area[a.x + 1, a.y] == 'E' || area[a.x + 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x + 1, y = a.y });
                            area[a.x + 1, a.y] = 'R';
                            a.satisfaction = 0;
                        }
                    }
                    else if (area[a.x, a.y - 1] == 'R')
                    {
                        if (area[a.x, a.y + 1] == 'E' || area[a.x, a.y + 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y + 1 });
                            area[a.x, a.y + 1] = 'R';
                            a.satisfaction = 0;
                        }
                    }
                    else if (area[a.x, a.y + 1] == 'R')
                    {
                        if (area[a.x, a.y - 1] == 'E' || area[a.x, a.y - 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y - 1 });
                            area[a.x, a.y - 1] = 'R';
                            a.satisfaction = 0;
                        }
                    }
                }   // fuck like grass spawn
            }
            foreach (var ras in spwn)
            {
                ra.Add(new Rabbit() { x = ras.x, y = ras.y });                  
            }
            int i = spwn.Count;
            spwn.Clear();

            foreach (var a in wo)
            {
                if (a.x != 0 && a.y != 0 && a.x != size - 1 && a.y != size - 1 && a.satisfaction >= 4)
                {
                    if (area[a.x + 1, a.y] == 'W')
                    {
                        if (area[a.x - 1, a.y] == 'E' || area[a.x - 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x - 1, y = a.y });
                            area[a.x - 1, a.y] = 'W';
                            a.satisfaction = 0;
                        }
                    }
                    else if (area[a.x - 1, a.y] == 'W')
                    {
                        if (area[a.x + 1, a.y] == 'E' || area[a.x + 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x + 1, y = a.y });
                            area[a.x + 1, a.y] = 'W';
                            a.satisfaction = 0;
                        }
                    }
                    else if (area[a.x, a.y - 1] == 'W')
                    {
                        if (area[a.x, a.y + 1] == 'E' || area[a.x, a.y + 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y + 1 });
                            area[a.x, a.y + 1] = 'W';
                            a.satisfaction = 0;
                        }
                    }
                    else if (area[a.x, a.y + 1] == 'W')
                    {
                        if (area[a.x, a.y - 1] == 'E' || area[a.x, a.y - 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y - 1 });
                            area[a.x, a.y - 1] = 'W';
                            a.satisfaction = 0;
                        }
                    }
                }   // fuck like grass spawn
            }
            foreach (var ras in spwn)
            {
                wo.Add(new Wolf() { x = ras.x, y = ras.y });
            }
            i += spwn.Count;
            spwn.Clear();
            return i;
        }

        static char[,] GrassGrowing(int size, char[,] area)
        {
            for (int i = 1; i < size-1; i++)
            {
                for (int j = 1; j < size-1; j++)
                {
                    if((area[i, j] == 'G') && ((area[i+1, j] == 'E') || (area[i-1, j] == 'E') || (area[i, j+1] == 'E') || (area[i, j-1] == 'E')))
                    {
                        Random ran = new Random();
                        int chance = ran.Next(0, 5);
                        //Console.WriteLine("Chance: " + chance);
                        while (chance == 0)
                        {
                            int direction = ran.Next(0, 4);
                            //Console.WriteLine("Direction: " + direction);
                            if ((direction == 0) && (area[i + 1, j] == 'E'))
                            {
                                area[i + 1, j] = 'G';
                                break;
                            }
                            else if ((direction == 1) && (area[i - 1, j] == 'E'))
                            {
                                area[i - 1, j] = 'G';
                                break;
                            }
                            else if ((direction == 2) && (area[i, j + 1] == 'E'))
                            {
                                area[i, j + 1] = 'G';
                                break;
                            }
                            else if ((direction == 3) && (area[i, j - 1] == 'E'))
                            {
                                area[i, j - 1] = 'G';
                                break;
                            }
                        }
                    }
                }
            }
            return area;
        }

        static void DisplayArea(int size, char[,] area, int turn, List<Wolf> wo, List<Rabbit> ra, int born)                      // Output Array
        {
            Console.WriteLine("\nTurn: " + turn);
            Console.WriteLine("-----------\nWolves: " + wo.Count);
            Console.WriteLine("Rabbits: " + ra.Count);
            Console.WriteLine("Born: " + born + "\n");
            for (int i = 0; i < size; i++)
            {
                Console.Write("    ");
                for (int j = 0; j < size; j++)
                {                    
                    if(area[i, j] == 'G')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(area[i, j] + " ");
                    }
                    else if (area[i, j] == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(area[i, j] + " ");
                    }
                    else if (area[i, j] == 'W')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(area[i, j] + " ");
                    }
                    else if (area[i, j] == 'R')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(area[i, j] + " ");
                    }
                }
                Console.Write("\n");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        static void Briefing()
        {
            Console.WriteLine("Welcome to game \"Live\"!\n ");
            Console.WriteLine("How to play: \n");
            Console.WriteLine("Enter size of your game board (area)");
            Console.WriteLine("Press Enter to start next turn \n");
            Console.WriteLine("Actions: \n");
            Console.WriteLine("If you want restart game, write \"restart\"");
            Console.WriteLine("If you want finish game, write \"exit\"");
            Console.WriteLine("If you want spawn new characters, write \"spawn\"");
            Console.WriteLine("If you want see characters' locations, write \"coord\"\n");

        }

        static void Coord(List<Wolf> wo, List<Rabbit> ra)
        {
            int i = 0;
            Console.WriteLine("\nWolves locations:");
            foreach (var a in wo)
            {
                i++;
                Console.WriteLine(i + ": " + a.x + "  " + a.y);
            }
            i = 0;
            Console.WriteLine("\n\nRabbits locations:");
            foreach (var a in ra)
            {
                i++;
                Console.WriteLine(i + ": " + a.x + "  " + a.y);
            }
            Console.WriteLine("\n\n");
        }

        static void Main()
        {
            Start:
            Briefing();
            int size = Input(), turn = 0;
            char[,] area = new char[size, size];
            Console.WriteLine("Area size: " + size + "\n");
            List<Wolf> wo = new List<Wolf>();
            List<Rabbit> ra = new List<Rabbit>();
            List<Spawner> spwn = new List<Spawner>();
            EarthAndGrass(size, area);
            WolvesAndRabbits(size, area, wo, ra);
            while (true)
            {
                turn++;
                GrassGrowing(size, area);
                Live(area, wo, ra);
                MoveRA(size, area, ra);
                MoveWO(size, area, wo, ra);
                int born = Fuck(size, area, wo, ra, spwn);
                DisplayArea(size, area, turn, wo, ra, born);

                string state = Console.ReadLine();
                if (state == "exit") {
                    break;
                }
                else if (state == "restart"){
                    goto Start;
                }
                else if (state == "spawn")
                {
                    RandomSpawn(size, area, wo, ra);
                    DisplayArea(size, area, turn, wo, ra, born);
                }
                else if (state == "coord")
                {
                    Coord(wo, ra);
                }
            }
        }
    }
}

/*                if (a.x == 0 && a.y != 0 && a.y != size - 1)
                {
                    if (area[a.x, a.y - 1] == 'R')
                    {
                        if (area[a.x + 1, a.y] == 'E' || area[a.x + 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x + 1, y = a.y });
                        }
                    }
                    else if (area[a.x, a.y + 1] == 'R')
                    {
                        if (area[a.x + 1, a.y] == 'E' || area[a.x + 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x + 1, y = a.y });
                        }
                    }
                    else if (area[a.x + 1, a.y] == 'R')
                    {
                        if (area[a.x + 2, a.y] == 'E' || area[a.x + 2, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x + 2, y = a.y });
                        }
                    }
                }

                else if (a.y == 0 && a.x != 0 && a.x != size - 1)
                {
                    if (area[a.x + 1, a.y] == 'R')
                    {
                        if (area[a.x , a.y + 1] == 'E' || area[a.x, a.y + 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y + 1});
                        }
                    }
                    else if (area[a.x - 1, a.y] == 'R')
                    {
                        if (area[a.x, a.y + 1] == 'E' || area[a.x, a.y + 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y + 1 });
                        }
                    }
                    else if (area[a.x, a.y + 1] == 'R')
                    {
                        if (area[a.x, a.y + 2] == 'E' || area[a.x, a.y + 2] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y + 2 });
                        }
                    }
                }

                else if (a.x == size - 1 && a.y != 0 && a.y != size - 1)
                {
                    if (area[a.x, a.y + 1] == 'R')
                    {
                        if (area[a.x - 1, a.y] == 'E' || area[a.x - 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x - 1, y = a.y });
                        }
                    }
                    else if (area[a.x, a.y - 1] == 'R')
                    {
                        if (area[a.x - 1, a.y] == 'E' || area[a.x - 1, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x - 1, y = a.y });
                        }
                    }
                    else if (area[a.x - 1, a.y] == 'R')
                    {
                        if (area[a.x - 2, a.y] == 'E' || area[a.x - 2, a.y] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x - 2, y = a.y });
                        }
                    }
                }

                else if (a.y == size - 1 && a.x != 0 && a.x != size - 1)
                {
                    if (area[a.x + 1, a.y] == 'R')
                    {
                        if (area[a.x, a.y - 1] == 'E' || area[a.x, a.y - 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y - 1 });
                        }
                    }
                    else if (area[a.x - 1, a.y] == 'R')
                    {
                        if (area[a.x, a.y - 1] == 'E' || area[a.x, a.y - 1] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y - 1 });
                        }
                    }
                    else if (area[a.x, a.y - 1] == 'R')
                    {
                        if (area[a.x, a.y - 2] == 'E' || area[a.x, a.y - 2] == 'G')
                        {
                            spwn.Add(new Spawner() { x = a.x, y = a.y - 2 });
                        }
                    }
                }
*/