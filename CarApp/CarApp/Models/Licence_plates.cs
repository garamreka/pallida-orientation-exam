using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Models
{
    public class Licence_plates
    {
        [JsonIgnore]
        public long Id { get; set; }
        [MaxLength (7)]
        [RegularExpression(@"^[A-Z0-9''-'\s]{1,7}$", ErrorMessage = "Sorry, the submitted licence plate is not valid")]
        public string Plate { get; set; }
        public string Car_brand { get; set; }
        public string Car_model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }
}
