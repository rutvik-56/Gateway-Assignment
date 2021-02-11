using System;
using System.Collections.Generic;

using BookingApi.Entities;

namespace BookingApi.Data
{
    public class Services
    {
        public List<Booking> getAllBooking()
        {
            var tmp = new List<Booking>();

            for(int i=1; i<=10;i++)
            {
                tmp.Add(new Booking()
                {
                    id = i,
                    movie_id = ((i*i*i)%10) +1,
                    date = DateTime.Now,
                    total_person = (i*i*i)%8,
                    total_amount = ((i * i * i) % 8)* (i * 10 + 100)
                });
            }

            return tmp;
        }

        public Booking getBookingbyid(int id)
        {
            List<Booking> tmp = getAllBooking();
            return tmp[id-1];
        }
    }
}
