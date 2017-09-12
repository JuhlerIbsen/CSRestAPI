using System.Collections.Generic;
using MovieAppEntity.Movie;

namespace MovieAppDAL.Repositories
{
    public interface IRepository<T>
    {
        T Add(T type);
        List<T> ListAll();
        T FindById(int id);
        T Delete(int id);
    }
}