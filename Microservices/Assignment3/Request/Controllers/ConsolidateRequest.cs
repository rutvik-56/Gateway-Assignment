using Microsoft.AspNetCore.Mvc;
using Request.Utils;
using System.Collections.Generic;
using MovieApi.Entities;
using BookingApi.Entities;
using System;
using System.Threading.Tasks;

namespace Request.Controllers
{
    [ApiController]
    [CustomRateLimit(title ="Maximum Limit", time = 60)]
    public class ConsolidateRequest : ControllerBase
    {
        [Route("GetOrderByMovieId/{id}")]
        public async Task<Tuple<Movie, List<Booking>>> GetOrderByMovieId(int id)
        {
            var movies = await WebClient.GetRequest<List<Movie>>("http://localhost:61374/Movie/GetMovies");
            var bookings = await WebClient.GetRequest<List<Booking>>($"http://localhost:61382/Booking/GetBookingById/{id}");


            Movie pre = new Movie();

            foreach(Movie tt in movies)
            {
                if(tt.id == id)
                {
                    pre = tt;
                    break;
                }
            }

            Tuple<Movie,List<Booking>> tmp = new Tuple<Movie, List<Booking>>(pre, bookings);
            return tmp;
        }
    }
}
