using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongService : ISong
    {
        private readonly TunifyDbContext _context;

        public SongService(TunifyDbContext context)
        {
            //bridge-session
            _context = context;
        }
        public async Task<Song> CreateSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return song;
        }

        public async Task DeleteSong(int id)
        {
            var getSong = await GetSongById(id);
            _context.Songs.Remove(getSong);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Song>> GetAllSongs()
        {
            var allSongs = await _context.Songs.ToListAsync();
            return allSongs;
        }

        public async Task<Song> GetSongById(int songID)
        {
            var song = await _context.Songs.FindAsync(songID);
            return song;
        }

        public async Task<Song> UpdateSong(int id, Song song)
        {
            var existingSong = await _context.Songs.FindAsync(id);
            existingSong = song;
            await _context.SaveChangesAsync();
            return song;

        }
    }
}
