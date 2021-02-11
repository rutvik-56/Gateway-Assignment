using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{ 
    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        public Decimal price { get; set; }
        public string director { get; set; }
        public int rating { get; set; }
    }
}
