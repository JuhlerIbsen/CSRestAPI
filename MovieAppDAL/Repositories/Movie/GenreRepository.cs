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
        private static int _id = 1;

        public GenreRepository(InMemoryContext context)
        {
            _context = context;
        }

        public Genre Add(Genre genre)
        {
            genre.Id = _id++;
            _context.Genres.Add(genre);
            return genre;
        }

        public List<Genre> ListAll()
        {
            return _context.Genres.Include(m => m.Movies).ThenInclude(mg => mg.Movie).ToList();
        }

        public Genre FindById(int id)
        {
            return _context.Genres.Include(m => m.Movies).ThenInclude(mg => mg.Movie).FirstOrDefault(genre => genre.Id == id);
        }

        public Genre Delete(int id)
        {
            var genre = FindById(id);
            _context.Genres.Remove(genre);
            return genre;
        }
    }
}
