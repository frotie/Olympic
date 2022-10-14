using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Olympic.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public double Price { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [NotMapped]
        public Color Color { get; set; }

        public byte[] ColorDb
        {
            get
            {
                return new[] { Color.R, Color.G, Color.B };
            }

            set
            {
                Color = Color.FromRgb(value[0], value[1], value[2]);
            }
        }

        public DateTime Release { get; set; }

        public string BodyType { get; set; }

        public string TransmissionType { get; set; }

        public string VIN { get; set; }
    }
}
