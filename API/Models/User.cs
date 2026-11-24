using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.models;

    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string Role { get; set; } = "user";

    public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
}
