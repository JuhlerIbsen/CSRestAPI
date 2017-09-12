using MovieAppBLL.Services;
using MovieAppBLL.Services.Movie;
using MovieAppDAL;
using MovieAppEntity.Movie;

namespace MovieAppBLL
{
    public class BLLFacade
    {
        public IService<Movie> MovieService => new MovieService(new DALFacade());
        public IService<Genre> GenreService => new GenreService(new DALFacade());

        // Currently only have static methods.
        // public TimeConverter TimeCoverter => (new TimeConverter());
    }
}