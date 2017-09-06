using System.Collections.Generic;
using MovieAppEntity.Movie;

namespace MovieAppDAL.Repositorys
{
    public interface IRepository<T>
    {
        T Add(T type);
        List<T> ListAll();
        T FindById(int id);
        Movie Delete(int id);
    }
}