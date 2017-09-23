using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAppDAL.Context;
using MovieAppDAL.Entities.Movie;

namespace MovieAppDAL.Repositories.Movie
{
    class GenreRepository : IRepository<Genre>
    {

        private readonly InMemoryContext _context;

        public GenreRepository(InMemoryContext context)
        {
            _context = context;
        }

        public Genre Add(Genre genre)
        {
            _context.Genres.Add(genre);
            return genre;
        }

        public List<Genre> ListAll()
        {
            return _context.Genres.Include(m => m.Movies).ToList();
        }

        public Genre FindById(int id)
        {
            return _context.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public Genre Delete(int id)
        {
            var genre = FindById(id);
            _context.Genres.Remove(genre);
            return genre;
        }
    }
}
