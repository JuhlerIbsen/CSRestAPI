using Microsoft.EntityFrameworkCore;
using MovieAppDAL.Entities.Movie;

namespace MovieAppDAL.Context
{
    internal class InMemoryContext : DbContext
    {
        private static readonly DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("VideoDB").Options;

        public InMemoryContext() : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>()
                .HasOne(movie => movie.Genre)
                .WithMany(genre => genre.Movies)
                .HasForeignKey(movie => movie.Id);

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}