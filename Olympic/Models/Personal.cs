using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympic.Models
{
    public class Personal
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Lastname { get; set; }

        public string Post { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
