using System;

namespace Common
{
    public class Booking
    {
        public int id { get; set; }
        public int movie_id { get; set; }

        public DateTime date { get; set; }

        public int total_person { get; set; }

        public int total_amount { get; set; }
    }
}
