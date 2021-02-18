using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Calculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                //Look for any movies.
                if (context.Movie.Any())
                {
                    return; //DB has been seeded
                }

                context.Movie.AddRange(
                    new Calculator
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "12",
                        Price = 7.99M
                    },

                new Calculator
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },

                new Calculator
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "PG",
                        Price = 3.99M
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
