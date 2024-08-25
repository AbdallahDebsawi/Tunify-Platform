using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public TunifyDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
              .HasOne(u => u.Subscription)
              .WithMany(s => s.Users)
              .HasForeignKey(u => u.SubscriptionId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId)
                .OnDelete(DeleteBehavior.NoAction);

            // seeded  data 

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Admin", Email = "admin@tunify.com", JoinDate = DateTime.Now, SubscriptionId = 1 },
                new User { UserId = 2, Username = "JohnDoe", Email = "john.doe@tunify.com", JoinDate = DateTime.Now, SubscriptionId = 2 },
                new User { UserId = 3, Username = "JaneDoe", Email = "jane.doe@tunify.com", JoinDate = DateTime.Now, SubscriptionId = 2 }
            );

            // Seeding Subscriptions
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, SubscriptionType = "Free", Price = 0 },
                new Subscription { SubscriptionId = 2, SubscriptionType = "Premium", Price = 9.99M }
            );

            // Seeding Artists
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Artist 1", Bio = "Bio for Artist 1" },
                new Artist { ArtistId = 2, Name = "Artist 2", Bio = "Bio for Artist 2" }
            );

            // Seeding Albums
            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, AlbumName = "Album 1", ReleaseDate = new DateTime(2023, 1, 1), ArtistId = 1 },
                new Album { AlbumId = 2, AlbumName = "Album 2", ReleaseDate = new DateTime(2024, 1, 1), ArtistId = 2 }
            );

            // Seeding Songs
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = 300, Genre = "Pop" },
                new Song { SongId = 2, Title = "Song 2", ArtistId = 1, AlbumId = 1, Duration = 250, Genre = "Rock" },
                new Song { SongId = 3, Title = "Song 3", ArtistId = 2, AlbumId = 2, Duration = 200, Genre = "Jazz" }
            );

            // Seeding Playlists
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UserId = 1, PlaylistName = "Top Hits", CreatedDate = DateTime.Now },
                new Playlist { PlaylistId = 2, UserId = 2, PlaylistName = "Workout Mix", CreatedDate = DateTime.Now }
            );

            // Seeding PlaylistSongs
            modelBuilder.Entity<PlaylistSong>().HasData(
                new PlaylistSong { PlaylistSongId = 1, PlaylistId = 1, SongId = 1 },
                new PlaylistSong { PlaylistSongId = 2, PlaylistId = 1, SongId = 2 },
                new PlaylistSong { PlaylistSongId = 3, PlaylistId = 2, SongId = 3 }
            );

            //
        }
    }
}
