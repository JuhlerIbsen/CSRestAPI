using System.ComponentModel.DataAnnotations;

namespace MovieAppBLL.Entities.Movie
{
    public class MovieBO
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

    }
}