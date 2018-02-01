using System.Collections.Generic;

namespace Server.Data.Classes
{
    public class User
    {
        public User() => Todos = new List<Todo>();

        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
