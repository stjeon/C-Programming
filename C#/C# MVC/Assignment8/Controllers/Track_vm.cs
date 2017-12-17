using Assignment8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class TrackAdd
    {
        /*public TrackAdd()
        {
            Albums = new List<Album>();
        }
        public ICollection<Album> Albums { get; set; }*/
        [Required]
        public String Clerk { get; set; }
        public String Composers { get; set; }
        [Required]
        public String Genre { get; set; }
        [Required, StringLength(100)]
        public String Name { get; set; }
        /*[Key]
        public int TrackId { get; set; }*/
        [Key]
        public int Id { get; set; }
    }//End of TrackAdd

    public class TrackAddForm : TrackAdd
    {
        public SelectList GenreList { get; set; }
    }//End of TrackAddForm

    public class TrackBase : TrackAdd
    {
        /*[Key]
        public int Id { get; set; }*/
    }//End of TrackBase

    public class TrackEdit : TrackAdd
    {
        //[Key]
        //public int Id { get; set; }
    }//End of TrackEdit

    public class TrackEditForm : TrackEdit
    {
        public SelectList GenreList { get; set; }
    }//End of TrackEditForm

    public class TrackWithDetail : TrackBase
    {
        public TrackWithDetail()
        {
            Albums = new List<AlbumBase>();
            //AlbumNames = new List<String>();
        }
       // public ICollection<String> AlbumNames;
        [Display(Name = "Albums With Track")]
        public ICollection<AlbumBase> Albums { get; set; }
    }//End of TrackWithDetail
}