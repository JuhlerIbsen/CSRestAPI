using System;
using System.Collections.Generic;
using System.Linq;
using MovieAppBLL.Converters;
using MovieAppBLL.Entities.Movie;
using MovieAppDAL;

namespace MovieAppBLL.Services.Movie
{
    internal class MovieService : IService<MovieBO>
    {
        private readonly DALFacade _dalFacade;
        private readonly MovieConverter _movieConverter = new MovieConverter();

        /// <summary>
        ///     MovieService Constructor.
        /// </summary>
        /// <param name="dalFacade">facade to use in this instance.</param>
        public MovieService(DALFacade dalFacade)
        {
            _dalFacade = dalFacade;
        }

        /// <summary>
        ///     Add a movie to the database.
        /// </summary>
        /// <param name="movie">movie to add into the database.</param>
        /// <returns>the movie that has been added to the database.</returns>
        public MovieBO Add(MovieBO movie)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newMovie = unitOfWork.MovieRepository.Add(_movieConverter.Convert(movie));
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return _movieConverter.Convert(newMovie);
            }
        }

        /// <summary>
        ///     Return a list of all movies.
        /// </summary>
        /// <returns>All movies in the database.</returns>
        public List<MovieBO> ListAll()
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return unitOfWork.MovieRepository.ListAll().ConvertAll(_movieConverter.Convert).ToList();
            }
        }

        /// <summary>
        ///     Return a movie by id.
        /// </summary>
        /// <param name="id">id of the movie we want to find.</param>
        /// <returns>movie that was found.</returns>
        public MovieBO FindById(int movieId)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return _movieConverter.Convert(unitOfWork.MovieRepository.FindById(movieId));
            }
        }

        /// <summary>
        ///     Update the movie we pass in the parameter.
        /// </summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>Updated version of movie.</returns>
        public MovieBO Update(MovieBO movie)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var movieFromDb = unitOfWork.MovieRepository.FindById(movie.Id);

                if (movieFromDb != null)
                {
                    movieFromDb.Title = movie.Title;
                    movieFromDb.PricePrDay = movie.PricePrDay;
                    movieFromDb.Duration = movie.Duration;

                    unitOfWork.Complete();
                }
                else
                {
                    throw new InvalidOperationException("Movie not found.");
                }

                return _movieConverter.Convert(movieFromDb);
            }
        }

        /// <summary>
        ///     Delete a movie by id.
        /// </summary>
        /// <param name="movieId">the id of the movie to delete.</param>
        /// <returns>checks if the movie was deleted succesfully</returns>
        public MovieBO Delete(int movieId)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newMovie = unitOfWork.MovieRepository.Delete(movieId);
                unitOfWork.Complete();
                return _movieConverter.Convert(newMovie);
            }
        }
    }
}