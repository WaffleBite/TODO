using Microsoft.Data.SqlClient;
using System;
using TODO.Domain;

namespace TODO
{
    class Program
    {
        static int taskIdCounter = 1; //ger en unik ID till varje task

        // 3 delar: adress till instans ; databansnamn ; authentisering
        static string connectionString = "Data Source=.; Initial Catalog=TODO; Integrated Security=true"; 
        //funkar med att skriva .; eller (local); eller localhost; eller Data Source=127.0.0.1;
        //kan skriva Server istället för Data Source, och Database istället för Initial Catalog

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; //texten blir blå

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

                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Due date: ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        CreateTask(title, dueDate);

                        break;

                    case ConsoleKey.D2: //list to do

                        Console.WriteLine("ID  Title                  Due date                 Completed");
                        Console.WriteLine("___________________________________________________________________________");

                        var tasks = FetchAllTasks();

                        foreach (var task in tasks)
                        {
                            if (task == null) continue;

                            Console.WriteLine($"{task.Id} {task.Title}{task.DueDate.ToString().PadLeft(25, ' ')}");
                        }

                        Console.ReadKey(true);

                        //Console.WriteLine("[M]ark as completed");

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

        private static Task[] FetchAllTasks()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = @"SELECT Id
                            , Title
                            , DueDate
                            , Completed
                            FROM Task";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            //Console.WriteLine("Successfully connected to database manager instance");

            //skicka SQL-kommando till servern
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string id = dataReader["Id"].ToString();
                string title = dataReader["Title"].ToString();
                string dueDate = dataReader["DueDate"].ToString();
                string completed = dataReader["Completed"].ToString();

                Console.Write(id.PadRight(5, ' '));
                Console.Write(title.PadRight(20, ' '));
                Console.Write(dueDate.PadRight(20, ' '));
                Console.WriteLine(completed);
            }

            connection.Close();

            return new Task[100];
        }

        private static void CreateTask(string title, DateTime dueDate)
        {
            Task[] tasks = FetchAllTasks();

            tasks[GetIndexPosition()] = new Task(taskIdCounter++, title, dueDate);
        }

        static int GetIndexPosition()
        {
            Task[] tasks = FetchAllTasks();

            int result = -1;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] != null)
                {
                    continue;
                }
                if (tasks[i] == null)
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
