using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieAppBLL;
using MovieAppBLL.Entities.Movie;

namespace MovieAppUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private BLLFacade _bllFacade = new BLLFacade();

        [TestMethod]
        public void GetRelations()
        {

            var addedGenre = new GenreBO
            {
                Name = "Comedy"
            };

            _bllFacade.MovieService.Add(new MovieBO
            {
                Title = "Dude where's Michael.",
                Duration = 2 * 3600,
                PricePrDay = 5000,
                Genres = new List<GenreBO>
                {
                    addedGenre
                }
            });

            var movie = _bllFacade.MovieService.FindById(1);

            var foundGenre = movie.Genres.FirstOrDefault(genre => genre.Id == 1);

            Assert.AreEqual(addedGenre, foundGenre);

        }
    }
    }
}
