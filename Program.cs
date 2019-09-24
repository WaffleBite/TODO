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

            int taskIdCounter = 1; //ger en unik ID till varje task

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

                        taskList[GetIndexPosition()] = new Task(taskIdCounter++, title, dueDate);

                        break;

                    case ConsoleKey.D2: //list to do

                        Console.WriteLine("ID  Title                  Due date                 Completed");
                        Console.WriteLine("___________________________________________________________________________");

                        foreach (var task in taskList)
                        {
                            if (task == null) continue;

                            Console.WriteLine($"{task.Id} {task.Title}{task.DueDate.ToString().PadLeft(25, ' ')}");
                        }

                        Console.ReadKey(true);

                        //Console.WriteLine("[M]ark as completed");

                        //keyPressed = Console.ReadKey(true);

                        //switch (keyPressed.Key)
                        //{
                        //    case ConsoleKey.M:



                        //        break;
                        //}

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
