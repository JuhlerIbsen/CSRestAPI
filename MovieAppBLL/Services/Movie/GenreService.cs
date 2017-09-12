using System;
using System.Collections.Generic;
using System.Text;
using MovieAppDAL;
using MovieAppEntity.Movie;

namespace MovieAppBLL.Services.Movie
{
    class GenreService : IService<Genre>
    {

        private readonly DALFacade _dalFacade;

        public GenreService(DALFacade dalFacade)
        {
            _dalFacade = dalFacade;
        }

        public Genre Add(Genre genre)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newGenre = unitOfWork.GenreRepository.Add(genre);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return newGenre;
            }
        }

        public List<Genre> ListAll()
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return unitOfWork.GenreRepository.ListAll();
            }
        }

        public Genre FindById(int id)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return unitOfWork.GenreRepository.FindById(id);
            }
        }

        public Genre Update(Genre genre)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var genreFromDb = unitOfWork.GenreRepository.FindById(genre.Id);

                if (genreFromDb != null)
                {
                    genreFromDb.Name = genre.Name;

                    unitOfWork.Complete();
                }
                else
                {
                    throw new InvalidOperationException("Movie not found.");
                }

                return genreFromDb;

            }
        }

        public Genre Delete(int id)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newGenre = unitOfWork.GenreRepository.Delete(id);
                unitOfWork.Complete();
                return newGenre;
            }
        }
    }
}
