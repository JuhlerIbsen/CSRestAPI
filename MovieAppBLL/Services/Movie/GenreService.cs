using System;
using System.Collections.Generic;
using System.Linq;
using MovieAppBLL.Converters;
using MovieAppDAL;
using GenreBO = MovieAppBLL.Entities.Movie.GenreBO;

namespace MovieAppBLL.Services.Movie
{
    class GenreService : IService<GenreBO>
    {

        private readonly GenreConverter _genreConverter = new GenreConverter();
        private readonly DALFacade _dalFacade;

        public GenreService(DALFacade dalFacade)
        {
            _dalFacade = dalFacade;
        }

        public GenreBO Add(GenreBO genre)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newGenre = unitOfWork.GenreRepository.Add(_genreConverter.Convert(genre));
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return _genreConverter.Convert(newGenre);
            }
        }

        public List<GenreBO> ListAll()
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return unitOfWork.GenreRepository.ListAll().ConvertAll(_genreConverter.Convert).ToList();
            }
        }

        public GenreBO FindById(int id)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return _genreConverter.Convert(unitOfWork.GenreRepository.FindById(id));
            }
        }

        public GenreBO Update(GenreBO genre)
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

                return _genreConverter.Convert(genreFromDb);

            }
        }

        public GenreBO Delete(int id)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newGenre = unitOfWork.GenreRepository.Delete(id);
                unitOfWork.Complete();
                return _genreConverter.Convert(newGenre);
            }
        }
    }
}
