using API.models;

namespace API.Models;

public class Dog
{
    public int Id { get; set; }
    public required string Name {get; set; }
    public int AgeMonths { get; set; }
    public double WeightKg { get; set; }
    public required string ActivityLevel { get; set; }


    public int UserId { get; set; }
    public User? User {get; set; }
}