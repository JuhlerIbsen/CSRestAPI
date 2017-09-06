using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieAppBLL;
using MovieAppEntity.Movie;

namespace MovieAppRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private BLLFacade _bllFacade = new BLLFacade();

        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _bllFacade.MovieService.ListAll();
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public Movie Get(int id)
        {
            return _bllFacade.MovieService.FindById(id);
        }
        
        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody]Movie movie)
        {
            _bllFacade.MovieService.Add(movie);
        }
        
        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Movie movie)
        {

            if (movie.Id != id)
            {
                return BadRequest("Id in url and in your json object doesn't match.");
            }

            return  Ok(_bllFacade.MovieService.Update(movie));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bllFacade.MovieService.Delete(id);
        }
    }
}
