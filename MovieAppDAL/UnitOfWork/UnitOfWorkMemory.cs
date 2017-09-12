using MovieAppDAL.Context;
using MovieAppDAL.Repositories;
using MovieAppDAL.Repositories.Movie;
using MovieAppEntity.Movie;

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
            MovieRepository = new MovieRepositoryEFMemory(_context);
            GenreRepository = new GenreRepositoryEFMemory(_context);
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