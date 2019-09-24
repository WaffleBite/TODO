using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("[1] Add to do");
                Console.WriteLine("[2] List to do");
                Console.WriteLine("[3] Exit");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                Console.Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1: //add to do

                        break;

                    case ConsoleKey.D2: //list to do

                        break;

                    case ConsoleKey.D3: //exit

                        isRunning = false;
                        break;
                }
            }
        }
    }
}
