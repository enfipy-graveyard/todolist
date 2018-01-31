using System.Collections.Generic;
using System;

namespace Server.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complited { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<TagModel> Tags { get; set; }
    }
}
