namespace Assignment8.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Assignment8.Models.ApplicationDbContext>
    {
        Assignment8.Controllers.Manager m = new Controllers.Manager();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Assignment8.Models.ApplicationDbContext";
        }

        protected override void Seed(Assignment8.Models.ApplicationDbContext context)
        {
            //m.RemoveData();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
           
            //Add user roles
            m.UpdateUser(context, "executive@example.com", new List<String> { "Executive", "Coordinator", "Clerk", "Staff" });
            m.UpdateUser(context, "coordinator@example.com", new List<String> {  "Coordinator", "Clerk", "Staff" });
            m.UpdateUser(context, "clerk@example.com", new List<String> { "Clerk", "Staff" });
            m.UpdateUser(context, "staff@example.com", new List<String> { "Staff" });

       


            //Initial Genres
            var genres = new List<string> {
                "Alternative",
                "Blues",
                "Classical",
                "Country",
                "Indie",
                "Jazz",
                "Opera",
                "Pop",
                "R&B",
                "Rock",
            };
            //Load genres
            genres.ForEach(g => context.Genres.AddOrUpdate(a => a.Name, new Genre { Name = g }));

            //Initial Artists
            var artists = new List<Artist>
            {
                new Models.Artist { BirthName="John William Coltrane", Name = "John Coltrane", Genre = "Jazz", UrlArtist = "http://rubbercityreview.com/wp-content/uploads/2013/09/Coltrane.jpg",
                    BirthOrStartDate = new System.DateTime (1923, 09, 03), Executive = "executive@example.com" },

                new Models.Artist { BirthName="Joe Strummer, Mick Jones, Paul Simonon, Keith Levene, Terry Chimes",
                    Name = "The Clash", Genre = "Rock", UrlArtist = "https://en.wikipedia.org/wiki/The_Clash#/media/File:Clash_21051980_12_800.jpg",
                BirthOrStartDate= new System.DateTime(1976, 07, 04), Executive = "executive@example.com"},

                 new Models.Artist { BirthName="Frédéric François Chopin",Name = "Frédéric Chopin", Genre = "Classic", UrlArtist = "https://en.wikipedia.org/wiki/Fr%C3%A9d%C3%A9ric_Chopin#/media/File:Frederic_Chopin_photo.jpeg",
                BirthOrStartDate= new System.DateTime(1810, 03, 01), Executive = "executive@example.com"}
            };//end of list
            //load artists
            artists.ForEach(a => context.Artists.AddOrUpdate(b => b.Name, a));

            //Load Albums
            var albums = new List<Album> {
                new Models.Album { Name = "My Favourite Things", Genre="Jazz", UrlAlbum="https://upload.wikimedia.org/wikipedia/en/9/9b/My_Favorite_Things.jpg",
                ReleaseDate = new System.DateTime(1960, 10, 21), Coordinator="coordinator@example.com"},
                new Models.Album { Name = "A Love Supreme", Genre="Jazz", UrlAlbum="https://upload.wikimedia.org/wikipedia/en/9/9a/John_Coltrane_-_A_Love_Supreme.jpg",
                ReleaseDate = new System.DateTime(1964, 11, 09), Coordinator="coordinator@example.com"}
            };//end of list
              //load albums
            albums.ForEach(a => context.Albums.AddOrUpdate(b=> b.Name, a));

            //Load Tracks
            var tracks = new List<Track> {
                //Album 1
                new Track { Name = "My Favourite Things", Genre = "Jazz", Composers= "Oscar Hammerstein, Richard Rogers", Clerk= "clerk@example.com"},
                new Track { Name = "Every Time We Say Goodbye", Genre = "Jazz", Composers= "Cole Porter", Clerk= "clerk@example.com"},
                new Track { Name = "Summertime", Genre = "Jazz", Composers= "Ira Gerschwin, DuBose Heyward, George Gerschwin", Clerk= "clerk@example.com"},
                new Track { Name = "But Not for Me", Genre = "Jazz", Composers= "Ira Gerschwin, George Gerschwin", Clerk= "clerk@example.com"},
                new Track { Name = "My Favourite Things Part 2", Genre = "Jazz", Composers= "Oscar Hammerstein, Richard Rogers", Clerk= "clerk@example.com"},

                //Album 2
                new Track { Name = "Acknowledgment", Genre = "Jazz", Composers= "John Coltrane", Clerk= "clerk@example.com"},
                new Track { Name = "Resolution", Genre = "Jazz", Composers= "John Coltrane", Clerk= "clerk@example.com"},
                new Track { Name = "Pursuance", Genre = "Jazz", Composers= "John Coltrane", Clerk= "clerk@example.com"},
                new Track { Name = "Psalm", Genre = "Jazz", Composers= "John Coltrane", Clerk= "clerk@example.com"},
                new Track { Name = "Introduction", Genre = "Jazz", Composers= "John Coltrane, Andre Francis", Clerk= "clerk@example.com"}
            };
            //load tracks
            tracks.ForEach(t => context.Tracks.AddOrUpdate(b => b.Name, t));

            //Save Changes
            context.SaveChanges();
            //album to artist associations
            m.AssocArtistAlbums(context, "John Coltrane", "My Favourite Things");
            m.AssocArtistAlbums(context, "John Coltrane", "A Love Supreme");
            //albums to tracks associations
            m.AssocAlbumTracks(context, "My Favourite Things", "My Favourite Things");
            m.AssocAlbumTracks(context, "My Favourite Things", "Every Time We Say Goodbye");
            m.AssocAlbumTracks(context, "My Favourite Things", "Summertime");
            m.AssocAlbumTracks(context, "My Favourite Things", "But Not for Me");
            m.AssocAlbumTracks(context, "A Love Supreme", "Acknowledgment");
            m.AssocAlbumTracks(context, "A Love Supreme", "Resolution");
            m.AssocAlbumTracks(context, "A Love Supreme", "Pursuance");
            m.AssocAlbumTracks(context, "A Love Supreme", "Psalm");
            m.AssocAlbumTracks(context, "A Love Supreme", "Introduction");

        }
    }
}
