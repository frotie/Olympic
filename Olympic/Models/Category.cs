using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympic.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public List<Car> Cars { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
