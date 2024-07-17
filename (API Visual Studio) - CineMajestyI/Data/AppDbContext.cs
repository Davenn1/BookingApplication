using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Seats> Seats {get;set;}
        public DbSet<Room> Room { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Customer> Customers { get; set; }

    }
}
