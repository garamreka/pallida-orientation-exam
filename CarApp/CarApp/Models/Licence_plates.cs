using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Models
{
    public class Licence_plates
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public string Car_brand { get; set; }
        public string Car_model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }
}
