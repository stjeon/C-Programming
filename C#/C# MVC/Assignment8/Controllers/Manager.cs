using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment8.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Assignment8.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper instance
        public IMapper mapper;

        // Request user property...

        // Backing field for the property
        private RequestUser _user;

        // Getter only, no setter
        public RequestUser User
        {
            get
            {
                // On first use, it will be null, so set its value
                if (_user == null)
                {
                    _user = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);
                }
                return _user;
            }
        }

        // Default constructor...
        public Manager()
        {
            // If necessary, add constructor code here

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

                // Object mapper definitions
                //Artist Mappers
                cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
                cfg.CreateMap<Controllers.ArtistAdd, Models.Artist>();
                cfg.CreateMap<Models.Artist, Controllers.ArtistBase>();
                cfg.CreateMap<Controllers.ArtistAddForm, Models.Artist>();
                cfg.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();
                //Genre Mappers
                cfg.CreateMap<Models.Genre, Controllers.GenreBase>();
                //Album Mappers
                cfg.CreateMap<Models.Album, Controllers.AlbumWithDetail>();
                cfg.CreateMap<Models.Album, Controllers.AlbumBase>();
                cfg.CreateMap<Controllers.AlbumAdd, Models.Album>();
                cfg.CreateMap<Controllers.AlbumBase, Controllers.AlbumAddForm>();
                //Track Mappers
                cfg.CreateMap<Models.Track, Controllers.TrackBase>();
                cfg.CreateMap<Controllers.TrackAddForm, Models.Track>();
                cfg.CreateMap<Controllers.TrackAdd, Models.Track>();
                cfg.CreateMap<Models.Track, Controllers.TrackWithDetail>();
                cfg.CreateMap<Controllers.TrackWithDetail, Controllers.TrackEditForm>();
                cfg.CreateMap<Controllers.TrackBase, Controllers.TrackEditForm>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // ############################################################
        // RoleClaim

        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()


        //Arist Methods
        public IEnumerable<ArtistBase> ArtistGetAll()
        {
            return mapper.Map<IEnumerable<ArtistBase>>(ds.Artists.OrderBy(a => a.Name));
        }

        public ArtistBase ArtistGetById(int? id)
        {
            var o = ds.Artists.Find(id);
            return (o == null) ? null : mapper.Map<ArtistBase>(o);
        }

        public ArtistBase ArtistAdd(ArtistAdd newItem)
        {
            var addedItem = ds.Artists.Add(mapper.Map<Artist>(newItem));
            ds.SaveChanges();

            return (addedItem == null) ? null : mapper.Map<ArtistBase>(addedItem);
        }

        public IEnumerable<ArtistWithDetail> ArtistGetAllWithDetail()
        {
            return mapper.Map<IEnumerable<ArtistWithDetail>>
                (ds.Artists.Include("Albums").OrderBy(a => a.Name));
        }

        public ArtistWithDetail ArtistGetByIdWithDetail(int id)
        {
            var o = ds.Artists.Include("Albums").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : mapper.Map<ArtistWithDetail>(o);
        }
        //End of Artist Methods

        //Genre Methods
        public IEnumerable<GenreBase> GenreGetAll()
        {
            return mapper.Map<IEnumerable<GenreBase>>(ds.Genres.OrderBy(a => a.Name));
        }
        //End of genre methods

        //Album Methods
        public IEnumerable<AlbumWithDetail> AlbumGetAllWithDetail()
        {
            return mapper.Map<IEnumerable<AlbumWithDetail>>
                (ds.Albums.Include("Artists").Include("Tracks").OrderBy(a => a.Name));
        }

        public AlbumWithDetail AlbumGetByIdWithDetail(int id)
        {
            var o = ds.Albums.Include("Artists").Include("Tracks").SingleOrDefault(a => a.Id == id);
            return (o == null) ? null : mapper.Map<AlbumWithDetail>(o);
        }

        public AlbumWithDetail AlbumAdd(AlbumAdd newItem)
        {

            var o = ds.Albums.Add(mapper.Map<Album>(newItem));

            foreach (var item in newItem.ArtistIds)
            {
                var a = ds.Artists.Find(item);
                o.Artists.Add(a);
            }

            foreach (var item in newItem.TrackIds)
            {
                var b = ds.Tracks.Find(item);
                o.Tracks.Add(b);
            }

            ds.SaveChanges();

            return (o == null) ? null : mapper.Map<AlbumWithDetail>(o);
        }
        //end of album methods

        //Track Methods
        public IEnumerable<TrackBase> TrackGetAll()
        {
            return mapper.Map<IEnumerable<TrackBase>>(ds.Tracks.OrderBy(a => a.Name));
        }

        public TrackBase TrackGetById(int? id)
        {
            var o = ds.Tracks.Find(id);
            return (o == null) ? null : mapper.Map<TrackBase>(o);
        }

        public TrackBase TrackAdd(TrackAdd newItem)
        {
            var addedItem = ds.Tracks.Add(mapper.Map<Track>(newItem));
            ds.SaveChanges();
            return (addedItem == null) ? null : mapper.Map<TrackBase>(addedItem);
        }

        public IEnumerable<TrackWithDetail> TrackGetAllWithDetail()
        {
            return mapper.Map<IEnumerable<TrackWithDetail>>
                (ds.Tracks.Include("Albums").OrderBy(a => a.Name));
        }

        public TrackWithDetail TrackGetByIdWithDetail(int id)
        {
            var o = ds.Tracks.Include("Albums").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : mapper.Map<TrackWithDetail>(o);
        }

        public bool TrackDelete(int id)
        {
            var itemToDelete = ds.Tracks.Find(id);

            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                ds.Tracks.Remove(itemToDelete);
                ds.SaveChanges();
                return true;
            }
        }

        public TrackWithDetail TrackEdit(TrackEdit newItem)
        {

            var o = ds.Tracks.Find(newItem.Id);

            if (o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();
                return mapper.Map<TrackWithDetail>(o);
            }
        }
        //end of track methods





        // Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method

        public bool LoadData()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // ############################################################
            // Role claims

            if (ds.RoleClaims.Count() == 0)
            {
                // Add role claims here\  
                ds.RoleClaims.Add(new RoleClaim { Name = "Coordinator" });
                ds.RoleClaims.Add(new RoleClaim { Name = "Manager" });
                ds.RoleClaims.Add(new RoleClaim { Name = "Clerk" });
                ds.RoleClaims.Add(new RoleClaim { Name = "Admin" });

                ds.SaveChanges();
                done = true;
            }

            return done;
        }

        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.RoleClaims)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        //data association methods
        public void AssocArtistAlbums(Assignment8.Models.ApplicationDbContext context, string artistName, string albumName)
        {
            var artist = context.Artists.SingleOrDefault(a => a.Name == artistName);
            var album = artist.Albums.SingleOrDefault(a => a.Name == albumName);
            if (album == null)
            {
                artist.Albums.Add(context.Albums.Single(a => a.Name == albumName));
            }
        }

        public void AssocAlbumTracks(Assignment8.Models.ApplicationDbContext context, string albumName, string trackName)
        {
            var album = context.Albums.SingleOrDefault(a => a.Name == albumName);
            var track = album.Tracks.SingleOrDefault(t => t.Name == trackName);
            if (track == null)
            {
                album.Tracks.Add(context.Tracks.Single(t => t.Name == trackName));
            }
        }

        public void UpdateUser(Assignment8.Models.ApplicationDbContext context, string email, List<string> roles)
        {
            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    manager.Create(new IdentityRole { Name = role });
                }
            }

            if (!context.Users.Any(u => u.UserName == email))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = email };

                manager.Create(user, "Password123!");

                foreach (var role in roles)
                {
                    manager.AddToRole(user.Id, role);
                }
            }

        }

        // New "RequestUser" class for the authenticated user
        // Includes many convenient members to make it easier to render user account info
        // Study the properties and methods, and think about how you could use it

        // How to use...

        // In the Manager class, declare a new property named User
        //public RequestUser User { get; private set; }

        // Then in the constructor of the Manager class, initialize its value
        //User = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);

        public class RequestUser
        {
            // Constructor, pass in the security principal
            public RequestUser(ClaimsPrincipal user)
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    Principal = user;

                    // Extract the role claims
                    RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                    // User name
                    Name = user.Identity.Name;

                    // Extract the given name(s); if null or empty, then set an initial value
                    string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                    if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                    GivenName = gn;

                    // Extract the surname; if null or empty, then set an initial value
                    string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                    if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                    Surname = sn;

                    IsAuthenticated = true;
                    // You can change the string value in your app to match your app domain logic
                    IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
                }
                else
                {
                    RoleClaims = new List<string>();
                    Name = "anonymous";
                    GivenName = "Unauthenticated";
                    Surname = "Anonymous";
                    IsAuthenticated = false;
                    IsAdmin = false;
                }

                // Compose the nicely-formatted full names
                NamesFirstLast = $"{GivenName} {Surname}";
                NamesLastFirst = $"{Surname}, {GivenName}";
            }

            // Public properties
            public ClaimsPrincipal Principal { get; private set; }
            public IEnumerable<string> RoleClaims { get; private set; }

            public string Name { get; set; }

            public string GivenName { get; private set; }
            public string Surname { get; private set; }

            public string NamesFirstLast { get; private set; }
            public string NamesLastFirst { get; private set; }

            public bool IsAuthenticated { get; private set; }

            public bool IsAdmin { get; private set; }

            public bool HasRoleClaim(string value)
            {
                if (!IsAuthenticated) { return false; }
                return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
            }

            public bool HasClaim(string type, string value)
            {
                if (!IsAuthenticated) { return false; }
                return Principal.HasClaim(type, value) ? true : false;
            }
        }

    }
}