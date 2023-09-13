using Microsoft.EntityFrameworkCore;
using Midterm.Data;

namespace Midterm.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VideoGameContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VideoGameContext>>()))
            {
                if (context == null || context.VideoGame == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any Video Games.
                if (context.VideoGame.Any())
                {
                    return;   // DB has been seeded
                }

                context.VideoGame.AddRange(
                    new VideoGame
                    {
                        Title = "Spider-Man",
                        ReleaseDate = DateTime.Parse("2018-9-07"),
                        Genre = "Action-Adventure",
                        Publisher = "Insomniac Games",
                        MSRP = 59.99M,
                        Rating = 8.5,
                        Summary = "Sony Interactive Entertainment, Insomniac Games, and Marvel have teamed up to create an authentic Spider-Man adventure. " +
                        "This isn’t the Spider-Man you’ve met or ever seen before. This is an experienced Peter Parker who’s more masterful at fighting big crime in Marvel's New York. " +
                        "At the same time, he’s struggling to balance his chaotic personal life and career while the fate of millions of New Yorkers rest upon his shoulders."
                    },

                    new VideoGame
                    {
                        Title = "God of War",
                        ReleaseDate = DateTime.Parse("2018-4-20"),
                        Genre = "Action-Adventure",
                        Publisher = "Santa Monica Studio",
                        MSRP = 59.99M,
                        Rating = 9,
                        Summary = "Enter the Norse realm His vengeance against the Gods of Olympus years behind him, Kratos now lives as a man in the realm of Norse Gods and monsters. " +
                        "It is in this harsh, unforgiving world that he must fight to survive… And teach his son to do the same."
                    },

                    new VideoGame
                    {
                        Title = "Ghost of Tsushima",
                        ReleaseDate = DateTime.Parse("2020-7-17"),
                        Genre = "Action-Adventure",
                        Publisher = "Sucker Punch Productions",
                        MSRP = 59.99M,
                        Rating = 8,
                        Summary = "Set in 1274 on the Tsushima Island, the last samurai, Jin Sakai, must master a new fighting style, the way of the Ghost, to defeat the Mongol forces and fight for the freedom and independence of Japan."
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
