using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// Define a DataContext class that inherits from DbContext
public class DataContext : DbContext
{
    // Constructor for DataContext taking DbContextOptions as a parameter
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    // DbSet representing the collection of AppUser entities in the database
    public DbSet<AppUser> Users { get; set; }
}
