using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace Assignment8.Models
{
    // Add your design model classes below

    // Follow these rules or conventions:

    // To ease other coding tasks, the name of the 
    //   integer identifier property should be "Id"
    // Collection properties (including navigation properties) 
    //   must be of type ICollection<T>
    // Valid data annotations are pretty much limited to [Required] and [StringLength(n)]
    // Required to-one navigation properties must include the [Required] attribute
    // Do NOT configure scalar properties (e.g. int, double) with the [Required] attribute
    // Initialize DateTime and collection properties in a default constructor

    public class RoleClaim
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }

    public class Album
    {
        public Album()
        {
            Artists = new List<Artist>();
            Tracks = new List<Track>();
            ReleaseDate = DateTime.Now.AddYears(-25);
        }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public String Coordinator { get; set; }
        public String Genre { get; set; }
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String UrlAlbum { get; set; }

    }//end of album class

    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
            //Tracks = new List<Track>();
            BirthOrStartDate = DateTime.Now.AddYears(-25);
        }
        public virtual ICollection<Album> Albums { get; set; }
        //public ICollection<Track> Tracks { get; set; }

        public String BirthName { get; set; }
        public DateTime BirthOrStartDate { get; set; }
        public String Executive { get; set; }
        public String Genre { get; set; }
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public String Name { get; set; }
        public String UrlArtist { get; set; }
    }//end of artist class

    public class Track
    {
        public Track()
        {
            Albums = new List<Album>();
        }
        public virtual ICollection<Album> Albums { get; set; }
        public String Clerk { get; set; }
        public String Composers { get; set; }
        public String Genre { get; set; }
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public String Name { get; set; }
    }

    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }

}
