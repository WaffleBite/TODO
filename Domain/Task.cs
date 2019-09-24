using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class Task
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }

        public Task(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
        }
    }
}
