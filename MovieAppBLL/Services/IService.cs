using System.Collections.Generic;

namespace MovieAppBLL.Services
{
    public interface IService<T>
    {
        // C.R.U.D operations.
        T Add(T type);

        List<T> ListAll();
        T FindById(int id);
        T Update(T type);
        T Delete(int id);
    }
}