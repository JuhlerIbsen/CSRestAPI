using MovieAppDAL.Context;
using MovieAppDAL.Repositorys;
using MovieAppEntity.Movie;

namespace MovieAppDAL.UnitOfWork
{
    internal class UnitOfWorkMemory : IUnitOfWork
    {
        private readonly InMemoryContext context;

        public UnitOfWorkMemory()
        {
            context = new InMemoryContext();
            MovieRepository = new MovieRepositoryEFMemory(context);
        }

        public IRepository<Movie> MovieRepository { get; internal set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}