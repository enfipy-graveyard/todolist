using System.Collections.Generic;

namespace Server.Models
{
    public class AccountModel
    {
        public AccountModel() => Todos = new List<TodoModel>();

        public int? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TodoModel> Todos { get; set; }
    }
}
