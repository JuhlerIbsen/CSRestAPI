using MovieAppDAL.Context;
using MovieAppDAL.Entities.Movie;
using MovieAppDAL.Repositories;
using MovieAppDAL.Repositories.Movie;

namespace MovieAppDAL.UnitOfWork
{
    internal class UnitOfWorkMemory : IUnitOfWork
    {
        private readonly InMemoryContext _context;

        public IRepository<Movie> MovieRepository { get; internal set; }
        public IRepository<Genre> GenreRepository { get; internal set; }

        public UnitOfWorkMemory()
        {
            _context = new InMemoryContext();
            MovieRepository = new MovieRepository(_context);
            GenreRepository = new GenreRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}