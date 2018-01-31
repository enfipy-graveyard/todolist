using System.Collections.Generic;
using System;

namespace Server.Data.Classes
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complited { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
