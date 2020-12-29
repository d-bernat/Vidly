using System.Data.Entity;

namespace Vidly.Models
{
    public class ApplicationDbContext: DbContext
    {
        private ApplicationDbContext() { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}