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
    }
}
