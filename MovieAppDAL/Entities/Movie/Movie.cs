using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieAppDAL.Entities.Movie
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Range(0.95, double.MaxValue)]
        public double PricePrDay { get; set; }

        [Required]
        [Range(120, long.MaxValue)]
        public long Duration { get; set; }

        public IEnumerable<MovieGenre> Genres { get; set; }
        public Genre Genre { get; set; }
    }
}