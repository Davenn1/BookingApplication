using MoviesAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace MoviesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=Movies;Trusted_Connection=true;Encrypt=False");
        }
        public DbSet<Customer> Customer { get; set; }
    }
}
