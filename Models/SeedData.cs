using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcSong.Data;
using System;
using System.Linq;

namespace MvcSong.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcSongContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcSongContext>>()))
        {
            // Look for any Songs.
            if (context.Song.Any())
            {
                return;   // DB has been seeded
            }
            context.Song.AddRange(
                new Song
                {
                    Title = "Can't Help Falling in love with you",
                    ReleaseDate = DateTime.Parse("1961-11-22"),
                    Genre = "Pop",
                    Price = 2.99M,
                    Rating="Clean",
                },
                new Song
                {
                    Title = "Bohemian Rhapsody",
                    ReleaseDate = DateTime.Parse("1975-10-31"),
                    Genre = "Progressive Rock",
                    Price = 3.99M,
                    Rating="Clean"
                },
                new Song
                {
                    Title = "I want it that way",
                    ReleaseDate = DateTime.Parse("1999-4-12"),
                    Genre = "Pop",
                    Price = 2.99M,
                    Rating="Clean",
                },
                new Song
                {
                    Title = "In the End",
                    ReleaseDate = DateTime.Parse("2001-10-9"),
                    Genre = "Hard Rock",
                    Price = 3.99M,
                    Rating="Clean"
                }
            );
            context.SaveChanges();
        }
    }
}