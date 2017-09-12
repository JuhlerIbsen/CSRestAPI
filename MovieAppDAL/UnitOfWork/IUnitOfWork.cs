using System;
using MovieAppDAL.Entities.Movie;
using MovieAppDAL.Repositories;

namespace MovieAppDAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> MovieRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        int Complete();
    }
}