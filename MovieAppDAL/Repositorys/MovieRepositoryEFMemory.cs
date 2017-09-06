using System.Collections.Generic;
using System.Linq;
using MovieAppDAL.Context;
using MovieAppEntity.Movie;

namespace MovieAppDAL.Repositorys
{
    internal class MovieRepositoryEFMemory : IRepository<Movie>
    {
        private readonly InMemoryContext _context;

        public MovieRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }


        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            return movie;
        }

        public List<Movie> ListAll()
        {
            return _context.Movies.ToList();
        }

        public Movie FindById(int movieId)
        {
            return _context.Movies.FirstOrDefault(movie => movie.Id == movieId);
        }

        public Movie Delete(int movieId)
        {
            var movie = FindById(movieId);
            _context.Movies.Remove(movie);
            return movie;
        }
    }
}