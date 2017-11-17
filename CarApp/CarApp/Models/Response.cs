using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Models
{
    public class Response
    {
        public string Result { get; set; } = "Ok";
        public Object Data { get; set; }
    }
}
