using API.models;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set;}
    public DbSet<Dog> Dogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dog>()
        .HasOne(d => d.User)
        .WithMany(u => u.Dogs)
        .HasForeignKey(d => d.UserId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}