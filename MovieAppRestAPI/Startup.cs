using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAppBLL;
using MovieAppBLL.Entities.Movie;

namespace MovieAppRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                UseMockData();
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void UseMockData()
        {
            var bllFacade = new BLLFacade();

            var rand = new Random();

            var horrorGenre = bllFacade.GenreService.Add(new GenreBO
            {
                Name = "Horror"
            });

            var comedyGenre = bllFacade.GenreService.Add(new GenreBO
            {
                Name = "Comedy"
            });
            
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

        }
    }
}
