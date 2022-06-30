using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureWritten.Classes
{
    public class Edition
    {
        public Edition(int id, User user, string name, string type)
        {
            Id = id;
            User = user;
            Name = name;
            Type = type;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
    }
}
