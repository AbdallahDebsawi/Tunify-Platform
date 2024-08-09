using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistService : IArtist
    {
        private readonly TunifyDbContext _context;

        public ArtistService(TunifyDbContext context)
        {
            //bridge-session
            _context = context;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return artist;
        }

        public async Task DeleteArtist(int id)
        {
            var getArtist = await GetArtistById(id);
            _context.Artists.Remove(getArtist);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Artist>> GetAllArtists()
        {
            var allArtists = await _context.Artists.ToListAsync();
            return allArtists;
        }

        public async Task<Artist> GetArtistById(int artistID)
        {
            var artist = await _context.Artists.FindAsync(artistID);
            return artist;
        }

        public async Task<Artist> UpdateArtist(int id, Artist artist)
        {
            var existingArtist = await _context.Artists.FindAsync(id);
            existingArtist = artist;
            await _context.SaveChangesAsync();
            return artist;

        }
    }
}
