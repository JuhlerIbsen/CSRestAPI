using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieAppBLL;
using MovieAppEntity.Movie;

namespace MovieAppUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMovie()
        {
            var bllFacade    = new BLLFacade();

            // Should automaticly get Id = 1.
            var newMovie = new Movie
            {
                Title = "Michael in the woods.",
                Duration = 532 * 2
            };

            var addedMovie = bllFacade.MovieService.Add(newMovie);

            Assert.AreSame(newMovie, addedMovie);
            Assert.AreEqual(1, newMovie.Id);

            // New instance of BLLFacade.
            bllFacade = new BLLFacade();

            // Should automaticly get Id = 2.
            addedMovie = bllFacade.MovieService.Add(newMovie);

            Assert.AreEqual(2, newMovie.Id);
            Assert.AreSame(newMovie, addedMovie);

        }

    }
}
