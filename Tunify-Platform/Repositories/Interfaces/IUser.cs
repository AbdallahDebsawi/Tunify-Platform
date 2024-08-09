using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userID);
        Task<User> UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}
