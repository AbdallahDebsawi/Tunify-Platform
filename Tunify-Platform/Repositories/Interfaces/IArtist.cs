using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtist
    {
        Task<Artist> CreateArtist(Artist artist);
        Task<List<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(int artistID);
        Task<Artist> UpdateArtist(int id, Artist artist);
        Task DeleteArtist(int id);
    }
}
