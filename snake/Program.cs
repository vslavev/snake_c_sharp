using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Snake
{

    class Program
    {
        enum Direction
        {
            LEFT,
            UP,
            RIGHT,
            DOWN
        }

        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 36;
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            Random randomnummer = new Random();
            int score = 5;
            int gameover = 0;
            pixel hoofd = new pixel();
            hoofd.xpos = screenwidth / 2;
            hoofd.ypos = screenheight / 2;
            hoofd.schermkleur = ConsoleColor.Red;
            Direction movement = Direction.RIGHT;
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(1, screenwidth);
            int berryy = randomnummer.Next(1, screenheight);
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            bool buttonpressed = false;
            while (true)
            {
                Console.Clear();
                if (hoofd.xpos == screenwidth - 1 || hoofd.xpos == 0 || hoofd.ypos == screenheight - 1 || hoofd.ypos == 0)
                {
                    gameover = 1;
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, screenheight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(screenwidth - 1, i);
                    Console.Write("■");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.xpos && berryy == hoofd.ypos)
                {
                    score++;
                    berryx = randomnummer.Next(1, screenwidth - 2);
                    berryy = randomnummer.Next(1, screenheight - 2);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");
                    if (xposlijf[i] == hoofd.xpos && yposlijf[i] == hoofd.ypos)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(hoofd.xpos, hoofd.ypos);
                Console.ForegroundColor = hoofd.schermkleur;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = false;
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 100) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != Direction.DOWN && !buttonpressed)
                        {
                            movement = Direction.UP;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != Direction.UP && buttonpressed)
                        {
                            movement = Direction.DOWN;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != Direction.RIGHT && buttonpressed)
                        {
                            movement = Direction.LEFT;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != Direction.LEFT && buttonpressed)
                        {
                            movement = Direction.RIGHT;
                            buttonpressed = true;
                        }
                    }
                }
                xposlijf.Add(hoofd.xpos);
                yposlijf.Add(hoofd.ypos);
                switch (movement)
                {
                    case Direction.UP:
                        hoofd.ypos--;
                        break;
                    case Direction.DOWN:
                        hoofd.ypos++;
                        break;
                    case Direction.LEFT:
                        hoofd.xpos--;
                        break;
                    case Direction.RIGHT:
                        hoofd.xpos++;
                        break;
                }
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
        }
        class pixel
        {
            public int xpos { get; set; }
            public int ypos { get; set; }
            public ConsoleColor schermkleur { get; set; }
        }
    }
}

