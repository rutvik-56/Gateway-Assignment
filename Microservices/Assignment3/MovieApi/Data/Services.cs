using System;
using System.Collections.Generic;
using MovieApi.Entities;

namespace MovieApi.Data
{
    public class Services
    {
        public List<Movie> getAll()
        {
            var tmp = new List<Movie>();

            for(int i=1; i<=10;i++)
            {
                tmp.Add(new Movie()
                {
                    id = i,
                    name = "movie_"+i,
                    director = "director_"+i,
                    price = i*10+100,
                    rating = (i%5)+1
                });
            }

            return tmp;
            
        }
    }
}
