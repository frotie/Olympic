using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympic.Models
{
    public class WorkAccounting
    {
        public int Id { get; set; }

        public int OperationCode { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime RentStart { get; set; }

        public DateTime RentEnd { get; set; }

        public bool IsReserved { get; set; }

        public double Price { get; set; }
    }
}
