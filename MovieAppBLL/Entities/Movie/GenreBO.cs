using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieAppBLL.Entities.Movie
{
    public class GenreBO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        public IEnumerable<MovieBO> Movies { get; set; }

    }
}
