using MovieAppBLL.Services;
using MovieAppDAL;
using MovieAppEntity.Movie;

namespace MovieAppBLL
{
    public class BLLFacade
    {
        public IService<Movie> MovieService => new MovieService(new DALFacade());

        // Currently only have static methods.
        // public TimeConverter TimeCoverter => (new TimeConverter());
    }
}