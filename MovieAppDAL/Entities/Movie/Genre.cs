using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieAppDAL.Entities.Movie
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
        public Movie Movie { get; set; }

    }
}
