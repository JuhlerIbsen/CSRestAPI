using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAppDAL.Context;

namespace MovieAppDAL.Repositories.Movie
{
    internal class MovieRepository : IRepository<Entities.Movie.Movie>
    {
        
        private readonly InMemoryContext _context;
        private static int _id = 1;

        public MovieRepository(InMemoryContext context)
        {
            _context = context;
        }

        public Entities.Movie.Movie Add(Entities.Movie.Movie movie)
        {
            movie.Id = _id ++;
            _context.Movies.Add(movie);
            return movie;
        }

        public List<Entities.Movie.Movie> ListAll()
        {
            return _context.Movies.Include(movie => movie.Genres).ThenInclude(gc => gc.Genre).ToList();
        }

        public Entities.Movie.Movie FindById(int movieId)
        {
            return _context.Movies.Include(movie => movie.Genres).FirstOrDefault(movie => movie.Id == movieId);
        }

        public Entities.Movie.Movie Delete(int movieId)
        {
            var movie = FindById(movieId);
            _context.Movies.Remove(movie);
            return movie;
        }
    }
}