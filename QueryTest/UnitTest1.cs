using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieAppBLL;
using MovieAppBLL.Entities.Movie;
using MovieAppDAL.Context;
using MovieAppDAL.Entities.Movie;

namespace QueryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQuery()
        {

            BLLFacade bllFacade = new BLLFacade();

           InMemoryContext context = new InMemoryContext();


            var rand = new Random();

            var horrorGenre = new GenreBO
            {
                Name = "Horror"
            };

            var comedyGenre = new GenreBO
            {
                Name = "Comedy"
            };

            bllFacade.MovieService.Add(new MovieBO
            {
                Title = "The Michaelism.",
                PricePrDay = 749.95,
                Duration = rand.Next(120, 3600 * 5),
                Genres = new List<GenreBO>
                {
                    horrorGenre,
                    comedyGenre
                }
            });

            bllFacade.MovieService.Add(new MovieBO
            {
                Title = "Dude where's Michael?",
                PricePrDay = 300.95,
                Duration = 200,
                Genres = new List<GenreBO>
                {
                    comedyGenre
                }
            });


            var list = from movie in bllFacade.MovieService.ListAll()
                join genre in bllFacade.GenreService.ListAll()
                on movie.Id equals genre.MovieId
                select new { movie.Genres }; 
            

            foreach (var movie in list)
            {
                foreach (var genre in movie.Genres)
                {
                    
                }
            }
            Assert.AreEqual("d", "d");
        }
    }
}

