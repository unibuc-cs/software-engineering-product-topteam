using Microsoft.EntityFrameworkCore;
using backend_MT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace backend_MT
{
    public class ApplicationDbContext : IdentityDbContext<Profesor>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profesor> Profesori { get; set; }
    }
}
