using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Entities
{
    public class UserEnt
    {
        private int id;
        private string nameFull;
        private string name;
        private string password;

        public int Id { get => id; set => id = value; }
        public string NameFull { get => nameFull; set => nameFull = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
    }
}
