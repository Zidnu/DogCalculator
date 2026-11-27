using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.models;

    [Index(nameof(UserName), IsUnique = true)]
    public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public string Role { get; set; } = "user";
    public required string Password { get; set; }

    
}
