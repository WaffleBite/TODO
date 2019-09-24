using System;

namespace TODO.Domain
{
    class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDate { get; set; } // ? = kan få värdet null om man inte sätter värde, annars får den värdet 1-1-0001 12:00
        public DateTime? Completed { get; set; }
        public bool isCompleted
        {
            get
            {
                return Completed != null; //om det finns en datum satt på completed så är den klar, alltså inte är null
            }
        }

        public Task(int id, string title, DateTime dueDate)
        {
            Id = id;
            Title = title;
            DueDate = dueDate;
        }
    }
}
