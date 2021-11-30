using Ecom.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Absence> Absence { get; set; }

        public DbSet<Rota> Rota { get; set; }
    }
}
