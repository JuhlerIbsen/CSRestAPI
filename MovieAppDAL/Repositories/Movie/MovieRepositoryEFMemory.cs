using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAppDAL.Context;

namespace MovieAppDAL.Repositories.Movie
{
    internal class MovieRepositoryEFMemory : IRepository<MovieAppEntity.Movie.Movie>
    {
        
        private readonly InMemoryContext _context;
        private static int _id = 1;

        public MovieRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }


        public MovieAppEntity.Movie.Movie Add(MovieAppEntity.Movie.Movie movie)
        {
            movie.Id = _id ++;
            _context.Movies.Add(movie);
            return movie;
        }

        public List<MovieAppEntity.Movie.Movie> ListAll()
        {
            return _context.Movies.ToList();
        }

        public MovieAppEntity.Movie.Movie FindById(int movieId)
        {
            return _context.Movies.FirstOrDefault(movie => movie.Id == movieId);
        }

        public MovieAppEntity.Movie.Movie Delete(int movieId)
        {
            var movie = FindById(movieId);
            _context.Movies.Remove(movie);
            return movie;
        }
    }
}