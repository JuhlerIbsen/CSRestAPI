using MovieAppBLL.Entities.Movie;
using MovieAppBLL.Services;
using MovieAppBLL.Services.Movie;
using MovieAppDAL;
using GenreBO = MovieAppBLL.Entities.Movie.GenreBO;

namespace MovieAppBLL
{
    public class BLLFacade
    {
        public IService<MovieBO> MovieService => new MovieService(new DALFacade());
        public IService<GenreBO> GenreService => new GenreService(new DALFacade());

        // Currently only have a static methods.
        // public TimeConverter TimeCoverter => (new TimeConverter());
    }
}