using System;
using MovieAppDAL.Repositorys;
using MovieAppEntity.Movie;

namespace MovieAppDAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> MovieRepository { get; }
        int Complete();
    }
}