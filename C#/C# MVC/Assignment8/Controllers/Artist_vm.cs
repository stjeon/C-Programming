using Assignment8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class ArtistAdd:ArtistBase
    {
       
    }//end of ArtistAdd

    public class ArtistBase {
        public ArtistBase()
        {
            BirthOrStartDate = DateTime.Now.AddYears(-25);
        }
        public String BirthName { get; set; }
        public DateTime BirthOrStartDate { get; set; }
        [Required]
        public String Executive { get; set; }
        [Required]
        public String Genre { get; set; }
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public String Name { get; set; }
        [Required]
        public String UrlArtist { get; set; }

    }//end of ArtistBase

    public class ArtistAddForm : ArtistBase {
            public SelectList GenreList { get; set; }
    
    }//end of ArtistAddForm

    public class ArtistWithDetail : ArtistBase
    {
        public ArtistWithDetail()
        {
            Albums = new List<AlbumBase>();
        }
        public ICollection<AlbumBase> Albums { get; set; }
    }//end of ArtistWithDetail
}