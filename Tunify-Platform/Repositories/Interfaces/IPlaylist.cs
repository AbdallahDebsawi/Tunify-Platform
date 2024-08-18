using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlayList
    {
        Task<Playlist> CreatePlaylist(Playlist playlist);
        Task<List<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistById(int playlistID);
        Task<Playlist> UpdatePlaylist(int id, Playlist playlist);
        Task DeletePlaylist(int id);
        Task AddSongToPlaylist(int playlistID, int songID);
        Task<IEnumerable<Song>> GetSongsByPlaylistId(int playlistID);
    }
}
