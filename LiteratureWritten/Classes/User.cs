using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureWritten.Classes
{
    public class User
    {
        public User(int id, string login, int role)
        {  
            Id = id;
            Login = login;
            Role = role;
        }
        public string Login { get; set; }
        public int Role { get; set; }
        public int Id { get; set; }

    }
}
