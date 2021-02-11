using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApi.Entities;
using BookingApi.Data;

namespace BookingApi.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        [Route("GetBookings")]
        public List<Booking> Get()
        {
            return new Services().getAllBooking();
        }
        
        [Route("GetBookingById/{id}")]
        public Booking Get(int id)
        {
            return new Services().getBookingbyid(id);
        }
    }
}
