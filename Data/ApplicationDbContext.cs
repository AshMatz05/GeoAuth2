using Microsoft.EntityFrameworkCore;
using GeoAuth2.Models;

namespace GeoAuth2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
