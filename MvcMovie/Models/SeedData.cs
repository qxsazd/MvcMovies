using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Fast and the Furious",
                    ReleaseDate = DateTime.Parse("2001-6-22"),
                    Genre = "Thriller",
                    Rating = "R",
                    Price = 8M
                },
                  new Movie
                  {
                      Title = "2 Fast 2 Furious",
                      ReleaseDate = DateTime.Parse("2003-6-3"),
                      Genre = "Thriller",
                      Rating = "R",
                      Price = 9M
                  },
                new Movie
                {
                    Title = "The Wolf of Wall Street",
                    ReleaseDate = DateTime.Parse("2013-12-25"),
                    Genre = "Crime",
                    Rating = "R",
                    Price = 11M
                },
                new Movie
                {
                    Title = "Project X",
                    ReleaseDate = DateTime.Parse("2012-3-1"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 10M
                },
                new Movie
                {
                    Title = "Scary Movie",
                    ReleaseDate = DateTime.Parse("2000-7-7"),
                    Genre = "Horror film",
                    Rating = "R",
                    Price = 6M
                }
            );
            context.SaveChanges();
            if (context.Movie.Any())
            {
                return;  // DB has been seeded.
            }
        }
    }
}