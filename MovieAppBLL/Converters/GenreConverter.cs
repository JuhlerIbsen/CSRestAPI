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
                Name = genre.Name
            };
        }

        internal Genre Convert(GenreBO genreBo)
        {
            if (genreBo == null)
            {
                return null;
            }

            return new Genre
            {
                Id = genreBo.Id,
                Name = genreBo.Name
            };
        }
    }
}
