using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Olympic.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; } 

        public string Lastname { get; set; }

        public string DriveLicense { get; set; }

        public string Passport { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Lastname}";
        }
    }
}
