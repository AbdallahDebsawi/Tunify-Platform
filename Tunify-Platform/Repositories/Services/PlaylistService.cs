using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistService : IPlayList
    {
        private readonly TunifyDbContext _context;

        public PlaylistService(TunifyDbContext context)
        {
            //bridge-session
            _context = context;
        }

       
        public async Task<Playlist> CreatePlaylist(Playlist playlist)
        {
            //the DbSet that resposible of the 
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        public async Task DeletePlaylist(int id)
        {
            var getPlaylist = await GetPlaylistById(id);
            _context.Playlists.Remove(getPlaylist);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlist>> GetAllPlaylists()
        {
            var allPlaylists = await _context.Playlists.ToListAsync();
            return allPlaylists;
        }

        public async Task<Playlist> GetPlaylistById(int playlistID)
        {
            var playlist = await _context.Playlists.FindAsync(playlistID);
            return playlist;
        }

        

        public async Task<Playlist> UpdatePlaylist(int id, Playlist playlist)
        {
            var existingPlaylist = await _context.Playlists.FindAsync(id);
            existingPlaylist = playlist;
            await _context.SaveChangesAsync();
            return playlist;

        }
        public async Task AddSongToPlaylist(int playlistID, int songID)
        {
            // Check if the artist exists
            var playlist = GetPlaylistById(playlistID);
            if (playlist == null)
            {
                throw new Exception("Playlist not found");
            }

            // Check if the song exists
            var song = await _context.Songs.FindAsync(songID);
            if (song == null)
            {
                throw new Exception("Song not found");
            }

            // Create a new PlaylistSongs entry to associate the song with the playlist
            var playlistSong = new PlaylistSong
            {
                PlaylistId = playlistID,
                SongId = songID
            };

            // Add the association to the PlaylistSongs table
            _context.PlaylistSongs.Add(playlistSong);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsByPlaylistId(int playlistID)
        {
            var playlist = GetPlaylistById(playlistID);
            if (playlist == null)
            {
                throw new Exception("Playlist not found");
            }
            // Retrieve songs associated with the specified playlist
            var songs = await _context.PlaylistSongs
                .Where(ps => ps.PlaylistId == playlistID)
                .Include(ps => ps.Song) // Include the Song entity
                .Select(ps => ps.Song)  // Select the Song
                .ToListAsync();

            return songs;
        }
    }
}
