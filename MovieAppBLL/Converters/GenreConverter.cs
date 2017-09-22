using System.Linq;
using MovieAppBLL.Entities.Movie;
using MovieAppDAL.Entities.Movie;

namespace MovieAppBLL.Converters
{
    class GenreConverter
    {
        internal GenreBO Convert(Genre genre)
        {
            if (genre == null)
            {
                return null;
            }
            
            return new GenreBO()
            {
                Id = genre.Id,
                Name = genre.Name,
                Movies = (genre.Movies?.Select(m => new MovieBO
                {
                  Id  = m.MovieId,
                  Duration = m.Movie.Duration,
                  PricePrDay = m.Movie.PricePrDay,
                  Title = m.Movie?.Title

                }).ToList())
            };
        }

        internal Genre Convert(GenreBO genreBo)
        {
            if (genreBo == null)
            {
                return null;
            }

            return new Genre()
            {
                Id = genreBo.Id,
                Name = genreBo.Name,
                Movies = (genreBo.Movies?.Select(m => new MovieGenre
                {
                 GenreId   = genreBo.Id,
                 MovieId   = m.Id
                }).ToList())
            };
        }
    }
}
