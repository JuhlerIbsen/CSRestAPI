using System;
using System.Collections.Generic;
using MovieAppDAL;
using MovieAppEntity.Movie;

namespace MovieAppBLL.Services
{
    internal class MovieService : IService<MovieAppEntity.Movie.Movie>
    {
        private readonly DALFacade _dalFacade;

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
        public MovieAppEntity.Movie.Movie Add(MovieAppEntity.Movie.Movie movie)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newMovie = unitOfWork.MovieRepository.Add(movie);
                unitOfWork.Complete();
                unitOfWork.Dispose();
                return newMovie;
            }
        }

        /// <summary>
        ///     Return a list of all movies.
        /// </summary>
        /// <returns>All movies in the database.</returns>
        public List<MovieAppEntity.Movie.Movie> ListAll()
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return unitOfWork.MovieRepository.ListAll();
            }
        }

        /// <summary>
        ///     Return a movie by id.
        /// </summary>
        /// <param name="id">id of the movie we want to find.</param>
        /// <returns>movie that was found.</returns>
        public MovieAppEntity.Movie.Movie FindById(int movieId)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                return unitOfWork.MovieRepository.FindById(movieId);
            }
        }

        /// <summary>
        ///     Update the movie we pass in the parameter.
        /// </summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>Updated version of movie.</returns>
        public MovieAppEntity.Movie.Movie Update(MovieAppEntity.Movie.Movie movie)
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

                return movieFromDb;
            }
        }

        /// <summary>
        ///     Delete a movie by id.
        /// </summary>
        /// <param name="movieId">the id of the movie to delete.</param>
        /// <returns>checks if the movie was deleted succesfully</returns>
        public MovieAppEntity.Movie.Movie Delete(int movieId)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var newMovie = unitOfWork.MovieRepository.Delete(movieId);
                unitOfWork.Complete();
                return newMovie;
            }
        }
    }
}