using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieAppBLL;
using MovieAppBLL.Entities.Movie;
using MovieAppDAL.Entities.Movie;

namespace MovieAppRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {

        private readonly BLLFacade _bllFacade = new BLLFacade();

        // GET: api/Genre
        [HttpGet]
        public IEnumerable<GenreBO> Get()
        {
            return _bllFacade.GenreService.ListAll();
        }

        // GET: api/Genre/5
        [HttpGet("{id}", Name = "GetGenre")]
        public GenreBO Get(int id)
        {
             return _bllFacade.GenreService.FindById(id);
        }
        
        // POST: api/Genre
        [HttpPost]
        public IActionResult Post([FromBody]GenreBO genre)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(406, ModelState);
            }

            return Ok(_bllFacade.GenreService.Add(genre));

        }
        
        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GenreBO genre)
        {


            if (!ModelState.IsValid)
            {
                return StatusCode(406, ModelState);
            }

            if (genre.Id != id)
            {
                return StatusCode(409, "Genre id and the url id doesn't match.");
            }

            try
            {
                return Ok(_bllFacade.GenreService.Update(genre));
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bllFacade.GenreService.Delete(id);
        }
    }
}
