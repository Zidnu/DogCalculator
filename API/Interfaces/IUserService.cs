using API.models;

namespace API.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByUserName(string username);
        Task<User> Register(string username, string password);
    }
}