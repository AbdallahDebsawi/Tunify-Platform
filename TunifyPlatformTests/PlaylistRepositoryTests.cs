using Microsoft.EntityFrameworkCore;
using Moq;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace TunifyPlatformTests
{

    public class PlaylistRepositoryTests
    {
        [Fact]
        public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
        {
            // Arrange
            var playlistId = 1;
            var songs = new List<Song>
    {
        new Song { SongId = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = 3, Genre = "Pop" },
        new Song { SongId = 2, Title = "Song 2", ArtistId = 2, AlbumId = 2, Duration = 2, Genre = "Rock" }
    };

            var mockRepository = new Mock<IPlayList>();
            mockRepository.Setup(repo => repo.GetSongsByPlaylistId(playlistId))
                          .ReturnsAsync(songs.AsEnumerable()); 

            // Act
            var result = await mockRepository.Object.GetSongsByPlaylistId(playlistId);

            // Assert
            Assert.Equal(2, result.Count()); 
            Assert.Contains(result, s => s.Title == "Song 1");
            Assert.Contains(result, s => s.Title == "Song 2");
        }
    }
}