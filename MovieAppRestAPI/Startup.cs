using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovieAppBLL;
using MovieAppEntity.Movie;

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

            var movie = bllFacade.MovieService.Add(new Movie
            {
                Title = "The Michaelism.",
                PricePrDay = 749.95,
                Duration = rand.Next(120, 3600 * 5)
            });

            bllFacade.GenreService.Add(new Genre
            {
                Name = "Horror",
            });

        }
    }
}
