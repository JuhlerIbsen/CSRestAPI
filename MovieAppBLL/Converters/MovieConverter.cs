using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieAppBLL.Entities.Movie;
using MovieAppDAL.Entities.Movie;

namespace MovieAppBLL.Converters
{
    class MovieConverter
    { 

        internal MovieBO Convert(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new MovieBO
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                PricePrDay = movie.PricePrDay,
                Genres = (movie.Genres.Select(g => new GenreBO
                {
                    Id = g.GenreId,
                    Name = g.Genre?.Name
                }).ToList())
            };
        }

        internal Movie Convert(MovieBO movieBo)
        {

            if (movieBo == null)
            {
                return null;
            }

            return new Movie
            {
                Id = movieBo.Id,
                Title = movieBo.Title,
                Duration = movieBo.Duration,
                PricePrDay = movieBo.PricePrDay,
                Genres = (movieBo.Genres.Select(g => new MovieGenre()
                {
                    GenreId = g.Id,
                    MovieId = movieBo.Id
                }).ToList())
                
            };
        }

    }
}
