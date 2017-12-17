using Assignment8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class AlbumBase
    {
        public AlbumBase()
        {
            //Artists = new List<Artist>();
            ReleaseDate = DateTime.Now.AddYears(-25);
        }
        //public ICollection<Artist> Artists { get; set; }
        public String Coordinator { get; set; }
        [Required]
        public String Genre { get; set; }
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String UrlAlbum { get; set; }

    }
    public class AlbumAdd:AlbumBase
    {

        public AlbumAdd()
        {
            ArtistIds = new List<int>();
            TrackIds = new List<int>();
            //ReleaseDate = DateTime.Now.AddYears(-25);
        }

        public IEnumerable<int> ArtistIds { get; set; }

        public IEnumerable<int> TrackIds { get; set; }
    }

    public class AlbumAddForm : AlbumBase
    {
        public SelectList ArtistList { get; set; }
        
        public SelectList TrackList { get; set; }
       
        public SelectList GenreList { get; set; }
    }

    public class AlbumWithDetail : AlbumBase
    {
        public AlbumWithDetail()
        {
            Artists = new List<ArtistBase>();
            Tracks = new List<TrackBase>();
        }
   
        public IEnumerable<ArtistBase> Artists { get; set; }
       
        public IEnumerable<TrackBase> Tracks { get; set; }
    }
}