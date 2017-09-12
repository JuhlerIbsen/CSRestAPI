using System;
using MovieAppDAL.Repositories;
using MovieAppEntity.Movie;

namespace MovieAppDAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> MovieRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        int Complete();
    }
}