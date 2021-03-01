using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAssignment1.Models
{
    public class Passengers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> Phone { get; set; }
    }
}