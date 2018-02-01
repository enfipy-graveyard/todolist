using System.Collections.Generic;
using System;

namespace Server.Data.Classes
{
    public class Todo
    {
        public Todo()
        {
            Complited = false;
            Date = DateTime.UtcNow;
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complited { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
