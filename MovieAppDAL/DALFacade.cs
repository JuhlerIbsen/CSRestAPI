using MovieAppDAL.UnitOfWork;

namespace MovieAppDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork => new UnitOfWorkMemory();
    }
}