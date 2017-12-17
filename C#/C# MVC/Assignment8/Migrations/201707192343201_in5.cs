namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class in5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coordinator = c.String(),
                        Genre = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(nullable: false),
                        UrlAlbum = c.String(),
                        ArtistList_DataGroupField = c.String(),
                        ArtistList_DataTextField = c.String(),
                        ArtistList_DataValueField = c.String(),
                        GenreList_DataGroupField = c.String(),
                        GenreList_DataTextField = c.String(),
                        GenreList_DataValueField = c.String(),
                        TrackList_DataGroupField = c.String(),
                        TrackList_DataTextField = c.String(),
                        TrackList_DataValueField = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ArtistWithDetail_Id = c.Int(),
                        TrackWithDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtistWithDetails", t => t.ArtistWithDetail_Id)
                .ForeignKey("dbo.TrackWithDetails", t => t.TrackWithDetail_Id)
                .Index(t => t.ArtistWithDetail_Id)
                .Index(t => t.TrackWithDetail_Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coordinator = c.String(),
                        Genre = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(nullable: false),
                        UrlAlbum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BirthName = c.String(),
                        BirthOrStartDate = c.DateTime(nullable: false),
                        Executive = c.String(),
                        Genre = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        UrlArtist = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clerk = c.String(),
                        Composers = c.String(),
                        Genre = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistAddForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreList_DataGroupField = c.String(),
                        GenreList_DataTextField = c.String(),
                        GenreList_DataValueField = c.String(),
                        BirthName = c.String(),
                        BirthOrStartDate = c.DateTime(nullable: false),
                        Executive = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        UrlArtist = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistWithDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BirthName = c.String(),
                        BirthOrStartDate = c.DateTime(nullable: false),
                        Executive = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        UrlArtist = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TrackAddForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreList_DataGroupField = c.String(),
                        GenreList_DataTextField = c.String(),
                        GenreList_DataValueField = c.String(),
                        Clerk = c.String(nullable: false),
                        Composers = c.String(),
                        Genre = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackEditForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreList_DataGroupField = c.String(),
                        GenreList_DataTextField = c.String(),
                        GenreList_DataValueField = c.String(),
                        Clerk = c.String(nullable: false),
                        Composers = c.String(),
                        Genre = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackWithDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clerk = c.String(nullable: false),
                        Composers = c.String(),
                        Genre = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Artist_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_Id, t.Album_Id })
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.TrackAlbums",
                c => new
                    {
                        Track_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Track_Id, t.Album_Id })
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Track_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AlbumBases", "TrackWithDetail_Id", "dbo.TrackWithDetails");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AlbumBases", "ArtistWithDetail_Id", "dbo.ArtistWithDetails");
            DropForeignKey("dbo.TrackAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.TrackAlbums", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.ArtistAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.TrackAlbums", new[] { "Album_Id" });
            DropIndex("dbo.TrackAlbums", new[] { "Track_Id" });
            DropIndex("dbo.ArtistAlbums", new[] { "Album_Id" });
            DropIndex("dbo.ArtistAlbums", new[] { "Artist_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AlbumBases", new[] { "TrackWithDetail_Id" });
            DropIndex("dbo.AlbumBases", new[] { "ArtistWithDetail_Id" });
            DropTable("dbo.TrackAlbums");
            DropTable("dbo.ArtistAlbums");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TrackWithDetails");
            DropTable("dbo.TrackEditForms");
            DropTable("dbo.TrackAddForms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Genres");
            DropTable("dbo.GenreBases");
            DropTable("dbo.ArtistWithDetails");
            DropTable("dbo.ArtistAddForms");
            DropTable("dbo.Tracks");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
            DropTable("dbo.AlbumBases");
        }
    }
}
