using HastaKabul.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaKabul.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Hastalar> hastalars { get; set; }
    }
}
