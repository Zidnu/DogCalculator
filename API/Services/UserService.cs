using API.CustomExceptions;
using API.Data;
using API.Interfaces;
using API.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService(DataContext _repository, IPasswordHasher<User> _passwordHasher) : IUserService
    {
        public async Task <User?> GetByUserName(string username)
        {
            var user = await _repository.Users.FirstOrDefaultAsync( u => u.UserName.ToLower() == username.ToLower());
            return user;
        }

        public async Task<User> Register(string username, string password)
        {
            var existingUser = await GetByUserName(username);
            if (existingUser != null)
            {
                throw new UserRegistrationsException("username must be unique");
            }

            var user = new User
            {
                UserName = username,
                Role = "user",
                Password = ""
            };

            user.Password = _passwordHasher.HashPassword(user, password);

            await _repository.Users.AddAsync(user);
            await _repository.SaveChangesAsync();

            return user;
        }
    }
}