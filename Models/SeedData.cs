using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new MvcMovieContext(
        serviceProvider.GetRequiredService<
          DbContextOptions<MvcMovieContext>>()))
      {
        //look for any movies
        if (context.Movie.Any())
        {
          return; //DB has been seeded
        }
        context.Movie.AddRange(
          new Movie
          {
            Title = "Ghostbusters",
            ReleaseDate = DateTime.Parse("1989-2-12"),
            Genre = "Romantic Comedy",
            Price = 7.99M

          },
          new Movie
          {
            Title = "Ghostbusters 2",
            ReleaseDate = DateTime.Parse("1959-4-15"),
            Genre = "Comedy",
            Price = 9.99M

          },
          new Movie
          {
            Title = "Rio Bravo",
            ReleaseDate = DateTime.Parse("1959-4-15"),
            Genre = "Western",
            Price = 3.99M
          },

          new Movie
          {
            Title = "When Harry met Sally",
            ReleaseDate = DateTime.Parse("1989-2-12"),
            Genre = "Romantic Comedy",
            Price = 3.99M
          }

        );
        context.SaveChanges();
      }
    }
  }
}
