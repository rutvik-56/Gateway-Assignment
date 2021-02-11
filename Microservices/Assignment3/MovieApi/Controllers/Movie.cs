using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieApi.Data;
using MovieApi.Entities;
using System.Threading.Tasks;

namespace MovieApi.Controllers
{
    [ApiController]
    public class MovieController : ControllerBase
    {
        [Route("GetMovies")]
        public List<Movie> Get()
        {
            return new Services().getAll();
        }
    }
}
