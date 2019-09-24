using System;
using TODO.Domain;

namespace TODO
{
    class Program
    {
        static Task[] taskList = new Task[100];
        static void Main(string[] args)
        {
            bool isRunning = true;

            Task[] taskList = new Task[100];

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

                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Due date: ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        taskList[GetIndexPosition()] = new Task(title, dueDate);

                        break;

                    case ConsoleKey.D2: //list to do

                        break;

                    case ConsoleKey.D3: //exit

                        isRunning = false;
                        break;
                }
            }
        }
        static int GetIndexPosition()
        {
            int result = -1;
            for (int i = 0; i < taskList.Length; i++)
            {
                if (taskList[i] != null)
                {
                    continue;
                }
                if (taskList[i] == null)
                {
                    result = i;
                    break;
                }
                if (result == -1)
                {
                    throw new Exception("No avalible position");
                }
            }
            return result;
        }
    }
}
