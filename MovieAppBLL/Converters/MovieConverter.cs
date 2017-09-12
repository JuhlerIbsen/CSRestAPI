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
                PricePrDay = movie.PricePrDay
            };
        }

        internal Movie Convert(MovieBO movieBo)
        {

            var genreConverter = new GenreConverter();

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
                Genres = (movieBo.Genres.ToList().ConvertAll(genreConverter.Convert))
                
            };
        }

    }
}
